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
    public class GetTrainingDocumentsByTrainingQuery:IRequest<List<TrainingDocumentsRM>>
    {
        public int TrainingID { get; set; }
    }
    public class GetTrainingDocumentsByTrainingQueryHandler : IRequestHandler<GetTrainingDocumentsByTrainingQuery, List<TrainingDocumentsRM>>
    {
        private readonly ITrainingInfoService _trainingInfoService;

        public GetTrainingDocumentsByTrainingQueryHandler(ITrainingInfoService trainingInfoService)
        {
            _trainingInfoService = trainingInfoService;
        }
        public async Task<List<TrainingDocumentsRM>> Handle(GetTrainingDocumentsByTrainingQuery request, CancellationToken cancellationToken)
        {
            return await _trainingInfoService.GetTrainingDocumentsByTraining(request.TrainingID, cancellationToken);
        }
    }
}
