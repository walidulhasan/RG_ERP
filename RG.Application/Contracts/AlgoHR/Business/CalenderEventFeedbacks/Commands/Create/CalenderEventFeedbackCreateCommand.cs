using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.CalenderEventFeedbacks.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.CalenderEventFeedbacks.Commands.Create
{
    public class CalenderEventFeedbackCreateCommand:IRequest<RResult>
    {
        public CalenderEventFeedbackDTM model { get; set; }
    }
    public class CalenderEventFeedbackCreateCommandHandler : IRequestHandler<CalenderEventFeedbackCreateCommand, RResult>
    {
        private readonly ITrainingCalendarService _trainingCalendarService;

        public CalenderEventFeedbackCreateCommandHandler(ITrainingCalendarService trainingCalendarService)
        {
            _trainingCalendarService = trainingCalendarService;
        }
        public async Task<RResult> Handle(CalenderEventFeedbackCreateCommand request, CancellationToken cancellationToken)
        {
            return await _trainingCalendarService.CalenderEventFeedbackCreate(request.model,true);
        }
    }
}
