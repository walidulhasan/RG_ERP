using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.TrainingInfos.Commands.Update
{
    public class DeleteTrainingDocumentCommand:IRequest<RResult>
    {
        public int ID { get; set; }
    }
    public class DeleteTrainingDocumentCommandHandler : IRequestHandler<DeleteTrainingDocumentCommand, RResult>
    {
        private readonly ITrainingDocumentsService _trainingDocumentsService;

        public DeleteTrainingDocumentCommandHandler(ITrainingDocumentsService trainingDocumentsService)
        {
            _trainingDocumentsService = trainingDocumentsService;
        }
        public async Task<RResult> Handle(DeleteTrainingDocumentCommand request, CancellationToken cancellationToken)
        {
            return await _trainingDocumentsService.DeleteDocument(request.ID);
        }
    }
}
