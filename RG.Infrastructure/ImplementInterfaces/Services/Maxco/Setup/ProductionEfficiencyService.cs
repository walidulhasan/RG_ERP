using AutoMapper;
using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Setup.Production_Efficiency.Commands.DataTransferModel;
using RG.Application.Contracts.Maxco.Setup.Production_Efficiency.Queries.RequestRespondeModel;
using RG.Application.Interfaces.Repositories.Maxco.Setup;
using RG.Application.Interfaces.Services.Maxco.Setup;
using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Maxco.Setup
{
    public class ProductionEfficiencyService : IProductionEfficiencyService
    {
        private readonly IProductionEfficiencyRepository _productionEfficiencyRepository;
        private readonly IMapper _mapper;

        public ProductionEfficiencyService(IProductionEfficiencyRepository productionEfficiencyRepository , IMapper mapper)
        {
            _productionEfficiencyRepository = productionEfficiencyRepository;
            _mapper = mapper;
        }
        public async Task<RResult> SaveAndUpdate(ProductionEfficiencyDTM model)
        {
            var entity = _mapper.Map<ProductionEfficiencyDTM, GarmentsProductionEfficiency>(model);
            entity.IsActive = true;
            RResult result = new RResult();
            if (model.ID == 0)
            {
                var checkDuplicateDate = await _productionEfficiencyRepository.FindAllAsync(x => x.IsActive == true && x.IsRemoved == false && x.ProductionDate.Date == model.ProductionDate.Date);
                if (checkDuplicateDate.Count > 0)
                {                    
                    result.result = 0;
                    result.message = "Duplicate Production Date Found.";
                }
                else
                {
                    await _productionEfficiencyRepository.InsertAsync(entity, true);
                    result.result = 1;
                    result.message = "Successfully Insert Production Efficiency.";
                }
                
            }
            else
            {
                var dbEntity = await _productionEfficiencyRepository.GetByIdAsync(entity.ID);
                dbEntity.ID = entity.ID;
                dbEntity.ProductionDate = entity.ProductionDate;
                dbEntity.StandardEfficiencyPercent = entity.StandardEfficiencyPercent;
                dbEntity.OverAllEfficiencyPercent = entity.OverAllEfficiencyPercent;
                await _productionEfficiencyRepository.UpdateAsync(dbEntity, model.ID, true);
                result.result = 1;
                result.message = "Successfully Update Production Efficiency.";
            }
            return result;
        }

        public async Task<RResult> Remove(int id, bool saveChange)
        {
            RResult result = new();
            var entity = await _productionEfficiencyRepository.GetByIdAsync(id);
            entity.IsRemoved = true;
            await _productionEfficiencyRepository.UpdateAsync(entity, entity.ID, saveChange);
            result.result = 1;
            result.message= "Production Efficiency  Successfully Remove.";
            return result;
        }

        public IQueryable<ProductionEfficiencyRM> GetAllGridData()
        {
            return _productionEfficiencyRepository.GetAllGridData();
        }
    }
}
