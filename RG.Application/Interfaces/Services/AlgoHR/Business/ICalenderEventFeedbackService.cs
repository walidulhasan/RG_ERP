using RG.Application.Contracts.AlgoHR.Business.CalenderEventFeedbacks.Commands.DataTransferModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Business
{
    public interface ICalenderEventFeedbackService
    {
        Task<List<CalenderEventFeedbackDTM>> GetListCalenderEventFeedback(int ID, CancellationToken cancellationToken);
        Task<List<CalenderEventFeedbackDTM>> TraineeWiseGetFeedbackList(int ID, int UserId, CancellationToken cancellationToken);
    }
}
