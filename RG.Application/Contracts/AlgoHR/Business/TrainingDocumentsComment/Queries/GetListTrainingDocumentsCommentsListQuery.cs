using MediatR;
using RG.Application.Contracts.AlgoHR.Business.TrainingDocumentsComment.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.TrainingDocumentsComment.Queries
{
    public class GetListTrainingDocumentsCommentsListQuery:IRequest<List<TrainingDocumentsCommentDTM>>
    {
        public int id { get; set; }
    }
    public class GetListTrainingDocumentsCommentsListQueryHandler : IRequestHandler<GetListTrainingDocumentsCommentsListQuery, List<TrainingDocumentsCommentDTM>>
    {
        private readonly ITrainingDocumentsCommentsService _trainingDocumentsCommentsService;

        public GetListTrainingDocumentsCommentsListQueryHandler(ITrainingDocumentsCommentsService trainingDocumentsCommentsService)
        {
            _trainingDocumentsCommentsService = trainingDocumentsCommentsService;
        }
        public async Task<List<TrainingDocumentsCommentDTM>> Handle(GetListTrainingDocumentsCommentsListQuery request, CancellationToken cancellationToken)
        {
            return await _trainingDocumentsCommentsService.GetListTrainingDocumentsCommentsList(request.id,cancellationToken);
        }
    }
}
