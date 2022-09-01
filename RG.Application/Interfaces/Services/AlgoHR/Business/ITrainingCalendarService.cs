using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.CalenderEventFeedbacks.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Business.TrainingCalendars.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Business
{
    public  interface ITrainingCalendarService
    {
        Task<TrainingCalendarRM> GetTrainingCalendar(int year);
        Task<RResult> CalenderEventFeedbackCreate(CalenderEventFeedbackDTM model, bool saveChange);
    }
}
