using RG.Application.Contracts.AlgoHR.Business.CalenderEventFeedbacks.Commands.DataTransferModel;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AlgoHR.Business
{
    public interface ICalenderEventFeedbackRepository : IGenericRepository<CalenderEventFeedback>
    {
        Task<List<CalenderEventFeedbackDTM>> GetListCalenderEventFeedback(int ID, CancellationToken cancellationToken);
        Task<List<CalenderEventFeedbackDTM>> TraineeWiseGetFeedbackList(int ID,int UserId ,CancellationToken cancellationToken);
    }
}
