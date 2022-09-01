using Microsoft.EntityFrameworkCore;
using RG.Application.Contracts.AlgoHR.Business.CalenderEventFeedbacks.Commands.DataTransferModel;
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
    public class CalenderEventFeedbackRepository : GenericRepository<CalenderEventFeedback>, ICalenderEventFeedbackRepository
    {
        private readonly AlgoHRDBContext _dbCon;

        public CalenderEventFeedbackRepository(AlgoHRDBContext dbcon):base(dbcon)
        {
            _dbCon = dbcon;
        }

        public async Task<List<CalenderEventFeedbackDTM>> GetListCalenderEventFeedback(int ID, CancellationToken cancellationToken)
        {
            try
            {
                var data = _dbCon.CalenderEventFeedback.Where(x => x.EventDetailsID == ID && x.IsActive == true && x.IsRemoved == false)
                            .Select(x => new CalenderEventFeedbackDTM()
                            {
                                Comments=x.Comments,
                                EventDetailsID=x.EventDetailsID
                            });
                return await data.ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<List<CalenderEventFeedbackDTM>> TraineeWiseGetFeedbackList(int ID, int UserId, CancellationToken cancellationToken)
        {
            try
            {
                var data = _dbCon.CalenderEventFeedback.Where(x => x.EventDetailsID == ID && x.CreatedBy==UserId && x.IsActive == true && x.IsRemoved == false)
                            .Select(x => new CalenderEventFeedbackDTM()
                            {
                                Comments = x.Comments,
                                EventDetailsID = x.EventDetailsID
                            });
                return await data.ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
