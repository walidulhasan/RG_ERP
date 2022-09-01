using AutoMapper;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.KPIParticularValuess.Commands.DataTransferModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Business
{
    public class KPIParticularValuesService : IKPIParticularValuesService
    {
        private readonly IKPIParticularValuesRepository _kpiParticularValuesRepository;
        private readonly IMapper _mapper;

        public KPIParticularValuesService(IKPIParticularValuesRepository kpiParticularValuesRepository,IMapper mapper)
        {
            _kpiParticularValuesRepository = kpiParticularValuesRepository;
            _mapper = mapper;
        }
        public async Task<RResult> KPIParticularValuesCreate(List<CompanyKPICreateDTM> kpiData, CancellationToken cancellationToken)
        {
            RResult rResult = new();
            try
            {
                var entities = _mapper.Map<List<CompanyKPICreateDTM>, List<KPIParticularValues>>(kpiData);

                var newEntities = entities.Where(x => x.ID == 0).ToList();
                await _kpiParticularValuesRepository.InsertAsync(newEntities, true);

                var updatedEntities= entities.Where(x => x.ID > 0).ToList();
                foreach (var item in updatedEntities)
                {
                    var entity =await _kpiParticularValuesRepository.GetByIdAsync(item.ID);
                    entity.ParticularValue = item.ParticularValue;
                    await _kpiParticularValuesRepository.UpdateAsync(entity, true);
                }
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
            }
            catch (Exception)
            {
                rResult.result = 0;
                rResult.message = ReturnMessage.ErrorMessage;
            }
            return rResult;
        }
    }
}
