using AutoMapper;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.CalenderEventMasters.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Business.CalenderEventMasters.Query.RequestResponseModel;
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
    public class CalenderEventMasterService : ICalenderEventMasterService
    {
        private readonly IMapper _mapper;
        private readonly ICalenderEventMasterRepository _calenderEventMasterRepository;
        private readonly ICalenderEventDetailsRepository _calenderEventDetailsRepository;

        public CalenderEventMasterService(IMapper mapper, ICalenderEventMasterRepository calenderEventMasterRepository, ICalenderEventDetailsRepository calenderEventDetailsRepository)
        {
            _mapper = mapper;
            _calenderEventMasterRepository = calenderEventMasterRepository;
            _calenderEventDetailsRepository = calenderEventDetailsRepository;
        }

        public async Task<RResult> CalenderEventDetailsRemove(int id, bool saveChange)
        {
            RResult result = new();
            if (id > 0)
            {
                var entity = await _calenderEventDetailsRepository.GetByIdAsync(id);
                entity.IsRemoved = true;
                await _calenderEventDetailsRepository.UpdateAsync(entity, entity.ID, saveChange);
                result.result = 1;
                result.message = "Calender Event Details  Successfully Remove.";
            }
            else
            {
                result.result = 0;
                result.message = "Remove failed";
            }
            return result;
        }

        public async Task<RResult> CalenderEventMasterCreate(CalenderEventMastersDTM model, bool saveChange = true)
        {
            RResult result = new();
            try
            {

                if (model.ID == 0)
                {
                    await SaveMasteAndChild(model, saveChange, result);
                }
                else
                {
                    var detailEntities = _mapper.Map<List<CalenderEventDetail>, List<CalenderEventDetails>>(model.CalenderEventDetail);

                    foreach (var item in detailEntities)
                    {
                        if (item.ID > 0)
                        {
                            await EventDetailsUpdate(saveChange, result, item);

                        }
                        else
                        {
                            item.EventID = model.ID;
                            await _calenderEventDetailsRepository.InsertAsync(item, saveChange);
                            result.result = 1;
                            result.message = ReturnMessage.InsertMessage;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result.result = 0;
                result.message = ReturnMessage.ErrorMessage;
            }
            return result;
        }

        private async Task EventDetailsUpdate(bool saveChange, RResult result, CalenderEventDetails item)
        {
            var detailEntity = await _calenderEventDetailsRepository.GetByIdAsync(item.ID);
            detailEntity.EventTitle = item.EventTitle;
            detailEntity.EventDuration = item.EventDuration;
            detailEntity.EventDateTime = item.EventDateTime;
            detailEntity.EventTrainer = item.EventTrainer;
            detailEntity.EventVenue = item.EventVenue;
            detailEntity.Stakeholder = item.Stakeholder;
            detailEntity.TrainingType = item.TrainingType;
            detailEntity.TrainingCategoryID = item.TrainingCategoryID;

            await _calenderEventDetailsRepository.UpdateAsync(detailEntity, saveChange);
            result.result = 1;
            result.message = ReturnMessage.UpdateMessage;
        }

        private async Task SaveMasteAndChild(CalenderEventMastersDTM model, bool saveChange, RResult result)
        {
            var entity = _mapper.Map<CalenderEventMastersDTM, CalenderEventMaster>(model);
            await _calenderEventMasterRepository.InsertAsync(entity, saveChange);
            
            result.result = 1;
            result.statusCode = entity.ID;
            result.message = ReturnMessage.InsertMessage;
        }

        public async Task<List<CalenderEventDetailsRM>> GetListCalenderEventDetails(DateTime ScheduleDate, CancellationToken cancellationToken)
        {
            return await _calenderEventMasterRepository.GetListCalenderEventDetails(ScheduleDate, cancellationToken);
        }
    }
}
