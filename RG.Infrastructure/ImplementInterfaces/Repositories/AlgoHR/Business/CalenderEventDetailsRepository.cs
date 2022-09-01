using Microsoft.EntityFrameworkCore;
using RG.Application.Contracts.AlgoHR.Business.CalenderEventDetail.Queries.RequestResponseModel;
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
    public class CalenderEventDetailsRepository : GenericRepository<CalenderEventDetails>, ICalenderEventDetailsRepository
    {
        private readonly AlgoHRDBContext _dbCon;

        public CalenderEventDetailsRepository(AlgoHRDBContext con) :base(con)
        {
            _dbCon = con;
        }

        public async Task<List<GetAllCalenderEventDetailsRM>> GetAllCalenderEventDetail(GetAllCalenderEventDetailsQM qm, CancellationToken cancellationToken)
        {
            var data = from ced in _dbCon.CalenderEventDetails
                       join tt in _dbCon.TrainingType on ced.TrainingCategoryID equals tt.ID
                       where ced.IsActive == true && ced.IsRemoved == false
                       && (qm.TrainingCategoryID == 0 || qm.TrainingCategoryID == ced.TrainingCategoryID)
                       && (qm.Year == 0 || qm.Year == ced.EventDateTime.Year)
                       && (qm.Month == 0 || qm.Month == ced.EventDateTime.Month)
                       select new GetAllCalenderEventDetailsRM
                       {
                           ID=ced.ID,
                           EventTitle=ced.EventTitle,
                           EventVenue=ced.EventVenue,
                           EventDateTime=ced.EventDateTime,
                           EventTrainer=ced.EventTrainer,
                           EventDuration=ced.EventDuration,
                           TrainingType=ced.TrainingType,
                           TrainingCategory=tt.TrainingTypeName
                       };
            return await data.ToListAsync(cancellationToken);
        }
    }
}
