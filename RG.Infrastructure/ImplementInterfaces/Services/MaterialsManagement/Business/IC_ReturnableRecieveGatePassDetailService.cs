using AutoMapper;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Business.IC_ReturnableRecieveGatePassDetails.Commands.DataTransferModel;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Business
{
    public class IC_ReturnableRecieveGatePassDetailService : IIC_ReturnableRecieveGatePassDetailService
    {
        private readonly IIC_ReturnableRecieveGatePassDetailRepository iC_ReturnableGatePassReceiveHistoryRepository;
        private readonly IMapper mapper;
        private readonly IIC_ReturnableGatePassDetailService iC_ReturnableGatePassDetailService;

        public IC_ReturnableRecieveGatePassDetailService(IIC_ReturnableRecieveGatePassDetailRepository _iC_ReturnableGatePassReceiveHistoryRepository, IMapper _mapper
            , IIC_ReturnableGatePassDetailService _iC_ReturnableGatePassDetailService)
        {
            iC_ReturnableGatePassReceiveHistoryRepository = _iC_ReturnableGatePassReceiveHistoryRepository;
            mapper = _mapper;
            iC_ReturnableGatePassDetailService = _iC_ReturnableGatePassDetailService;
        }
        public async Task<RResult> SaveReturnableRecieveGatePassDetail(List<IC_ReturnableRecieveGatePassDetailDTM> model, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<List<IC_ReturnableRecieveGatePassDetailDTM>, List<IC_ReturnableRecieveGatePassDetail>>(model);
            var rResult = await iC_ReturnableGatePassReceiveHistoryRepository.SaveReturnableRecieveGatePassDetail(entity, cancellationToken);
            if (rResult.result == 1)
            {
                rResult = await iC_ReturnableGatePassDetailService.ReturnableGatePassDetailReceivedQuantityUpdate(model, cancellationToken);
            }
            return rResult;
        }
    }
}
