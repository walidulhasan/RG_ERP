using MediatR;
using RG.Application.Contracts.AlgoHR.Business.TrainingCalendars.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.TrainingCalendars.Queries
{
    public class GetTrainingCalendarQuery : IRequest<TrainingCalendarRM>
    {
        public int Year { get; set; }
    }
    public class GetTrainingCalendarQueryHandler : IRequestHandler<GetTrainingCalendarQuery, TrainingCalendarRM>
    {
        private readonly ITrainingCalendarService _trainingCalendarService;

        public GetTrainingCalendarQueryHandler(ITrainingCalendarService trainingCalendarService)
        {
            _trainingCalendarService = trainingCalendarService;
        }
        public async Task<TrainingCalendarRM> Handle(GetTrainingCalendarQuery request, CancellationToken cancellationToken)
        {
            return await _trainingCalendarService.GetTrainingCalendar(request.Year);
        }
    }
}
