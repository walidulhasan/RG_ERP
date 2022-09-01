using MediatR;
using RG.Application.Contracts.AlgoHR.Business.CalenderEventFeedbacks.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.CalenderEventFeedbacks.Queries
{
    public class TraineeWiseGetFeedbackListQuery:IRequest<List<CalenderEventFeedbackDTM>>
    {
        public int id { get; set; }
        public int UserId { get; set; }
    }
    public class TraineeWiseGetFeedbackListQueryHandler : IRequestHandler<TraineeWiseGetFeedbackListQuery, List<CalenderEventFeedbackDTM>>
    {
        private readonly ICalenderEventFeedbackService _calenderEventFeedbackService;

        public TraineeWiseGetFeedbackListQueryHandler(ICalenderEventFeedbackService calenderEventFeedbackService)
        {
            _calenderEventFeedbackService = calenderEventFeedbackService;
        }
        public async Task<List<CalenderEventFeedbackDTM>> Handle(TraineeWiseGetFeedbackListQuery request, CancellationToken cancellationToken)
        {
            return await _calenderEventFeedbackService.TraineeWiseGetFeedbackList(request.id,request.UserId,cancellationToken);
        }
    }
}
