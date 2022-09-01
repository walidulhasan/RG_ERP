using RG.Application.Contracts.AlgoHR.Business.TrainingCalendars.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AlgoHR.Business
{
    public  interface ITrainingCalendarRepository
    {
        Task<TrainingCalendarRM> GetTrainingCalendar(int year);
    }
}
