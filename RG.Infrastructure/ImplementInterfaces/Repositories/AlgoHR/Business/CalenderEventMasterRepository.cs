using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.CalenderEventMasters.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Business.CalenderEventMasters.Query.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using RG.Infrastructure.Persistence.AlgoHRDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Business
{
    public class CalenderEventMasterRepository : GenericRepository<CalenderEventMaster>, ICalenderEventMasterRepository
    {
        private readonly AlgoHRDBContext _con;

        public CalenderEventMasterRepository(AlgoHRDBContext con) :base(con)
        {
            _con = con;
        }

        public async Task<List<CalenderEventDetailsRM>> GetListCalenderEventDetails(DateTime ScheduleDate, CancellationToken cancellationToken)
        {
            try
            {
                var data = from cem in _con.CalenderEventMaster
                           join ced in _con.CalenderEventDetails
                           on cem.ID equals ced.EventID
                           where cem.ScheduleDate == ScheduleDate && cem.IsActive==true && cem.IsRemoved==false && ced.IsActive==true && ced.IsRemoved==false
                           select new CalenderEventDetailsRM
                           {
                               ID = ced.ID,
                               MasterID=cem.ID,
                               EventTitle = ced.EventTitle,
                               EventDateTime = ced.EventDateTime.ToString("dd-MMM-yyyy hh:mm tt"),
                               EventDuration = ced.EventDuration,
                               EventTrainer = ced.EventTrainer,
                               EventVenue = ced.EventVenue,
                               TrainingType=ced.TrainingType,
                               Stakeholder = ced.Stakeholder,
                               TrainingCategoryID=ced.TrainingCategoryID,
                               Time= ced.EventDateTime.ToString("HH:mm")
                           };
                return await data.ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {

                throw;
            }
           
        }
    }
}
