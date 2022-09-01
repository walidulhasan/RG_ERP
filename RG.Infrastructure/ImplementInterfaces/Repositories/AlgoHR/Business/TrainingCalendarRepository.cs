using RG.Application.Contracts.AlgoHR.Business.TrainingCalendars.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using RG.Infrastructure.Persistence.AlgoHRDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Business
{
    public class TrainingCalendarRepository :GenericRepository<TrainingInfo>,ITrainingCalendarRepository
    {
        private readonly AlgoHRDBContext _dbCon;
        public TrainingCalendarRepository(AlgoHRDBContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<TrainingCalendarRM> GetTrainingCalendar(int year)
        {
            var calendar = new TrainingCalendarRM();

            try
            {
                await _dbCon.LoadStoredProc("ajt.usp_GetYearlyTrainingCalendar")
                                .WithSqlParam("Year", year)
                                .ExecuteStoredProcAsync((handler) =>
                                {
                                    calendar.WeekDays = handler.ReadToList<Day>().ToList();
                                    handler.NextResult();
                                    calendar.CalendarDays = handler.ReadToList<CalendarDay>().ToList();
                                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return calendar;
        }
    }
}
