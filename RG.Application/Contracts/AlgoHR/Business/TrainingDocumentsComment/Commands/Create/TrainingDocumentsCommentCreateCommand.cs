using MediatR;
using RG.Application.Common.Mappings;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.TrainingDocumentsComment.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.TrainingDocumentsComment.Commands.Create
{
    public class TrainingDocumentsCommentCreateCommand:IRequest<RResult>
    {
       public TrainingDocumentsCommentDTM dtModel { get; set; }
    }
    public class TrainingDocumentsCommentCreateCommandHandler : IRequestHandler<TrainingDocumentsCommentCreateCommand, RResult>
    {
        private readonly ITrainingInfoService _trainingInfoService;

        public TrainingDocumentsCommentCreateCommandHandler(ITrainingInfoService trainingInfoService)
        {
            _trainingInfoService = trainingInfoService;
        }
        public async Task<RResult> Handle(TrainingDocumentsCommentCreateCommand request, CancellationToken cancellationToken)
        {
            return await _trainingInfoService.TrainingDocumentsCommentCreate(request.dtModel,true);
        }
    }
}
