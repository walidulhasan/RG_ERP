using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceItem_Setups.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceItem_Setups.Commands.Update
{
   public class MT_MaintenanceItem_SetupUpdateCommand:IRequest<RResult>
    {
        public MT_MaintenanceItem_SetupDTM MT_MaintenanceItem_Setup { get; set; }
        public bool SaveChange { get; set; }
    }
    public class MT_MaintenanceItem_SetupUpdateCommandHandler : IRequestHandler<MT_MaintenanceItem_SetupUpdateCommand, RResult>
    {
        private readonly IMT_MaintenanceItem_SetupService mT_MaintenanceItem_SetupService;

        public MT_MaintenanceItem_SetupUpdateCommandHandler(IMT_MaintenanceItem_SetupService _mT_MaintenanceItem_SetupService)
        {
            mT_MaintenanceItem_SetupService = _mT_MaintenanceItem_SetupService;
        }
        public async Task<RResult> Handle(MT_MaintenanceItem_SetupUpdateCommand request, CancellationToken cancellationToken)
        {
            return await mT_MaintenanceItem_SetupService.UpdateMT_MaintenanceItem(request.MT_MaintenanceItem_Setup, request.SaveChange);
        }
    }
}
