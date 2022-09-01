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
    public class DeleteTrainingCommand:IRequest<RResult>
    {
        public int ID { get; set; }
    }
    public class DeleteTrainingCommandHandler : IRequestHandler<DeleteTrainingCommand, RResult>
    {
        private readonly ITrainingInfoService _trainingInfoService;

        public DeleteTrainingCommandHandler(ITrainingInfoService trainingInfoService)
        {
            _trainingInfoService = trainingInfoService;
        }
        public async Task<RResult> Handle(DeleteTrainingCommand request, CancellationToken cancellationToken)
        {
            return await _trainingInfoService.DeleteTraining(request.ID);
        }
    }
}
