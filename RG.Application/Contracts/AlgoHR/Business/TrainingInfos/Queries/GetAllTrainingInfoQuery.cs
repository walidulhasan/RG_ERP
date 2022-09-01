using MediatR;
using RG.Application.Contracts.AlgoHR.Business.TrainingInfos.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.TrainingInfos.Queries
{
    public class GetAllTrainingInfoQuery:IRequest<List<TrainingInfoRM>>
    {
        public int TrainingTypeID { get; set; }
    }
    public class GetAllTrainingInfoQueryHandler : IRequestHandler<GetAllTrainingInfoQuery, List<TrainingInfoRM>>
    {
        private readonly ITrainingInfoService _trainingInfoService;

        public GetAllTrainingInfoQueryHandler(ITrainingInfoService trainingInfoService)
        {
            _trainingInfoService = trainingInfoService;
        }
        public async Task<List<TrainingInfoRM>> Handle(GetAllTrainingInfoQuery request, CancellationToken cancellationToken)
        {
            return await _trainingInfoService.GetAllTrainingInfo(request.TrainingTypeID, cancellationToken);
        }
    }
}
