using MediatR;
using Microsoft.AspNetCore.Http;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.TrainingInfos.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.TrainingInfos.Commands.Create
{
    public class TrainingInfoCreateCommand:IRequest<RResult>
    {
        public TrainingInfoDTM TrainingInfo { get; set; }
        public IFormFileCollection Files { get; set; }
    }
    public class TrainingInfoCreateCommandHandler : IRequestHandler<TrainingInfoCreateCommand, RResult>
    {
        private readonly ITrainingInfoService _trainingInfoService;

        public TrainingInfoCreateCommandHandler(ITrainingInfoService trainingInfoService)
        {
            _trainingInfoService = trainingInfoService;
        }
        public async Task<RResult> Handle(TrainingInfoCreateCommand request, CancellationToken cancellationToken)
        {
            return await _trainingInfoService.Create(request.TrainingInfo, request.Files, cancellationToken);
        }
    }
}
