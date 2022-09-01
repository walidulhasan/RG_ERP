using AutoMapper;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.CalenderEventFeedbacks.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Business.TrainingCalendars.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Business
{
    public class TrainingCalendarService : ITrainingCalendarService
    {
        private readonly ITrainingCalendarRepository _trainingCalendarRepository;
        private readonly IMapper _mapper;
        private readonly ICalenderEventFeedbackRepository _calenderEventFeedbackRepository;

        public TrainingCalendarService(ITrainingCalendarRepository trainingCalendarRepository, IMapper mapper, ICalenderEventFeedbackRepository calenderEventFeedbackRepository)
        {
            _trainingCalendarRepository = trainingCalendarRepository;
            _mapper = mapper;
            _calenderEventFeedbackRepository = calenderEventFeedbackRepository;
        }

        public async Task<RResult> CalenderEventFeedbackCreate(CalenderEventFeedbackDTM model, bool saveChange)
        {
            try
            {


                RResult result = new();
                var entity = _mapper.Map<CalenderEventFeedbackDTM, CalenderEventFeedback>(model);
                var obj = await _calenderEventFeedbackRepository.InsertAsync(entity, saveChange);
                if (obj != null)
                {
                    result.result = 1;
                    result.message = "Thanks For Feedback";
                }
                else
                {
                    result.result = 0;
                    result.message = ReturnMessage.ErrorMessage;
                }
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<TrainingCalendarRM> GetTrainingCalendar(int year)
        {
            return await _trainingCalendarRepository.GetTrainingCalendar(year);
        }
    }
}
