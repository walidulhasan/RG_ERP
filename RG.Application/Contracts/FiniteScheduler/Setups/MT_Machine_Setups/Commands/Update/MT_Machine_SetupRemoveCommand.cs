using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.MT_Machine_Setups.Commands.Update
{
    public class MT_Machine_SetupRemoveCommand:IRequest<RResult>
    {
        public int MachineID { get; set; }
    }
    public class MT_Machine_SetupRemoveCommandHandler : IRequestHandler<MT_Machine_SetupRemoveCommand, RResult>
    {
        private readonly IMT_Machine_SetupService mT_Machine_SetupService;

        public MT_Machine_SetupRemoveCommandHandler(IMT_Machine_SetupService _mT_Machine_SetupService)
        {
            mT_Machine_SetupService = _mT_Machine_SetupService;
        }
        public async Task<RResult> Handle(MT_Machine_SetupRemoveCommand request, CancellationToken cancellationToken)
        {
            return await mT_Machine_SetupService.RemoveMachine(request.MachineID, true);
        }
    }
}
