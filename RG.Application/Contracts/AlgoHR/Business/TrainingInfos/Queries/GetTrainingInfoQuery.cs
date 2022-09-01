using MediatR;
using RG.Application.Contracts.AlgoHR.Business.TrainingInfos.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.TrainingInfos.Queries
{
    public class GetTrainingInfoQuery:IRequest<TrainingInfoRM>
    {
        public int ID { get; set; }
    }
    public class GetTrainingInfoQueryHandler : IRequestHandler<GetTrainingInfoQuery, TrainingInfoRM>
    {
        private readonly ITrainingInfoService _trainingInfoService;

        public GetTrainingInfoQueryHandler(ITrainingInfoService trainingInfoService)
        {
            _trainingInfoService = trainingInfoService;
        }
        public async Task<TrainingInfoRM> Handle(GetTrainingInfoQuery request, CancellationToken cancellationToken)
        {
            return await _trainingInfoService.GetTrainingInfo(request.ID, cancellationToken);
        }
    }
}
