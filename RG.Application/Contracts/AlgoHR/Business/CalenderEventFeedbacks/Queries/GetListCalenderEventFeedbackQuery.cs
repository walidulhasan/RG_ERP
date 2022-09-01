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
    public class GetListCalenderEventFeedbackQuery:IRequest<List<CalenderEventFeedbackDTM>>
    {
        public int id { get; set; }
    }
    public class GetListCalenderEventFeedbackQueryHandelr : IRequestHandler<GetListCalenderEventFeedbackQuery, List<CalenderEventFeedbackDTM>>
    {
        private readonly ICalenderEventFeedbackService _calenderEventFeedbackService;

        public GetListCalenderEventFeedbackQueryHandelr(ICalenderEventFeedbackService calenderEventFeedbackService)
        {
            _calenderEventFeedbackService = calenderEventFeedbackService;
        }
        public async Task<List<CalenderEventFeedbackDTM>> Handle(GetListCalenderEventFeedbackQuery request, CancellationToken cancellationToken)
        {
            return await _calenderEventFeedbackService.GetListCalenderEventFeedback(request.id,cancellationToken);
        }
    }
}
