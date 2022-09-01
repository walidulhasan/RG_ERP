using AutoMapper;
using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Setup.CuttingAdditionFabricRequireds.Commands.DataTransferModel;
using RG.Application.Contracts.Maxco.Setup.CuttingAdditionFabricRequireds.Queries.RequestResponseModel;
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
    public class CuttingAdditionFabricRequiredService : ICuttingAdditionFabricRequiredService
    {
        private readonly ICuttingAdditionFabricRequiredRepository _cuttingAdditionFabricRequiredRepository;
        private readonly IMapper mapper;

        public CuttingAdditionFabricRequiredService(ICuttingAdditionFabricRequiredRepository cuttingAdditionFabricRequiredRepository, IMapper mapper)
        {
            _cuttingAdditionFabricRequiredRepository = cuttingAdditionFabricRequiredRepository;
            this.mapper = mapper;
        }

        public IQueryable<CuttingAdditionFabricRM> GetCuttingAdditionFabricRequiredList(DateTime DateFrom, DateTime DateTo, int BuyerId = 0, long OrderID = 0)
        {
            return _cuttingAdditionFabricRequiredRepository.GetCuttingAdditionFabricRequiredList(DateFrom, DateTo, BuyerId, OrderID);
        }

        public async Task<RResult> RemoveCuttingAdditionFabricRequired(int ID, bool saveChange)
        {
            RResult result = new RResult();
            var entity = await _cuttingAdditionFabricRequiredRepository.GetByIdAsync(ID);
            entity.IsRemoved = true;
            await _cuttingAdditionFabricRequiredRepository.UpdateAsync(entity, entity.ID, saveChange);
            result.result = 1;
            result.message = "Successfully Update Cutting Required.";
            return result;
        }

        public async Task<RResult> SaveAndUpdate(CuttingAdditionalFabricDTM model)
        {
            var entity = mapper.Map<CuttingAdditionalFabricDTM, CuttingAdditionFabricRequired>(model);
            RResult result = new RResult();
            if (model.ID == 0)
            {
                await _cuttingAdditionFabricRequiredRepository.InsertAsync(entity, true);
                result.result = 1;
                result.message = "Successfully Insert Cutting Required.";
            }
            else
            {
                var dbEntity = await _cuttingAdditionFabricRequiredRepository.GetByIdAsync(entity.ID);
                dbEntity.OrderID = entity.OrderID;
                dbEntity.PlanQuantity = entity.PlanQuantity;
                dbEntity.RequisitionDate = entity.RequisitionDate;
                dbEntity.RequisitionQuantity = entity.RequisitionQuantity;
                //dbEntity.StandardEfficiencyPercent = entity.StandardEfficiencyPercent;
                //dbEntity.OverAllEfficiencyPercent = entity.OverAllEfficiencyPercent;

                await _cuttingAdditionFabricRequiredRepository.UpdateAsync(dbEntity, model.ID, true);
                result.result = 1;
                result.message = "Successfully Update Cutting Required.";
            }
            return result;
        }



    }
}
