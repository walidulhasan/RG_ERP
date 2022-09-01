using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_Machine_Setups.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.MT_Machine_Setups.Commands.Create
{
    public class MT_Machine_SetupCreateCommand : IRequest<RResult>
    {
        public MT_Machine_SetupDTM MT_Machine_SetupDTM { get; set; }
        public bool SaveChange { get; set; }
    }
    public class MT_Machine_SetupCreateCommandHandler : IRequestHandler<MT_Machine_SetupCreateCommand, RResult>
    {
        private readonly IMT_Machine_SetupService mT_Machine_SetupService;

        public MT_Machine_SetupCreateCommandHandler(IMT_Machine_SetupService _mT_Machine_SetupService)
        {       
            mT_Machine_SetupService = _mT_Machine_SetupService;
        }
        public async Task<RResult> Handle(MT_Machine_SetupCreateCommand request, CancellationToken cancellationToken)
        {
            return await mT_Machine_SetupService.SaveMachine(request.MT_Machine_SetupDTM, request.SaveChange);
        }
    }
}
