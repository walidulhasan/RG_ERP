using AutoMapper;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Setups.DailyProductionHour.Commands.DataTransferModel;
using RG.Application.Contracts.MaterialsManagement.Setups.DailyProductionHour.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Setups;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Setups
{
    public class DailyProductionHourService : IDailyProductionHourService
    {
        private readonly IDailyProductionHourRepository _dailyProductionHourRepository;
        private readonly IMapper _mapper;

        public DailyProductionHourService(IDailyProductionHourRepository dailyProductionHourRepository, IMapper mapper)
        {
            _dailyProductionHourRepository = dailyProductionHourRepository;
            _mapper = mapper;
        }
        public async Task<RResult> SaveAndUpdate(DailyProductionHourDTM model)
        {
            var entity = _mapper.Map<DailyProductionHourDTM, DailyProductionHour>(model);
            entity.IsActive = true;
            RResult result = new RResult();

            if (model.ID == 0)
            {
                var tableCurrentId =await _dailyProductionHourRepository.MaxTableId();
                entity.ID = tableCurrentId;
                var obj = await _dailyProductionHourRepository.InsertAsync(entity, true);
                if (obj != null)
                {
                    result.result = 1;
                    result.message = "Successfully Insert Daily Production Hour.";
                }
                else
                {
                    result.result = 0;
                    result.message = "Somthing is Missing!!!";
                }

            }
            else
            {
                var dbEntity = await _dailyProductionHourRepository.GetByIdAsync(entity.ID);
                dbEntity.ProductionType = entity.ProductionType;
                dbEntity.TimeFrom = entity.TimeFrom;
                dbEntity.TimeTo = entity.TimeTo;
                dbEntity.LapTiming = entity.LapTiming;
                dbEntity.Description = entity.Description;
                await _dailyProductionHourRepository.UpdateAsync(dbEntity, model.ID, true);
                result.result = 1;
                result.message = "Successfully Update Daily Production Hour.";
            }
            return result;
        }

        public async Task<RResult> Remove(int ID, bool saveChange)
        {
            RResult result = new();
            var entity = await _dailyProductionHourRepository.GetByIdAsync(ID);
            entity.IsRemoved = true;
            var obj = await _dailyProductionHourRepository.UpdateAsync(entity, entity.ID, saveChange);
            if (obj != null)
            {

                result.result = 1;
                result.message = ReturnMessage.DeleteMessage;
            }
            else
            {
                result.result = 0;
                result.message = ReturnMessage.ErrorMessage;
            }
            return result;
        }

        public IQueryable<DailyProductionhourRM> GetAllGridData()
        {
            return _dailyProductionHourRepository.GetAllGridData();
        }
    }
}
