using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.AlgoHR.Business.CalenderEventFeedbacks.Commands.DataTransferModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Business
{
    public class CalenderEventFeedbackService : ICalenderEventFeedbackService
    {
        private readonly ICalenderEventFeedbackRepository _calenderEventFeedbackRepository;
        private readonly ICurrentUserService _currentUserService;

        public CalenderEventFeedbackService(ICalenderEventFeedbackRepository calenderEventFeedbackRepository, ICurrentUserService currentUserService )
        {
            _calenderEventFeedbackRepository = calenderEventFeedbackRepository;
            _currentUserService = currentUserService;
        }
        public async Task<List<CalenderEventFeedbackDTM>> GetListCalenderEventFeedback(int ID, CancellationToken cancellationToken)
        {
            return await _calenderEventFeedbackRepository.GetListCalenderEventFeedback(ID , cancellationToken);
        }

        public async Task<List<CalenderEventFeedbackDTM>> TraineeWiseGetFeedbackList(int ID, int UserId, CancellationToken cancellationToken)
        {
            return await _calenderEventFeedbackRepository.TraineeWiseGetFeedbackList(ID,_currentUserService.UserID,cancellationToken);
        }
    }
}
