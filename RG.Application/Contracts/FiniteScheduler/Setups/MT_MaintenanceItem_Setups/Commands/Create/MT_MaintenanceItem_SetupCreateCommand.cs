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

namespace RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceItem_Setups.Commands.Create
{
   public class MT_MaintenanceItem_SetupCreateCommand:IRequest<RResult>
    {
        public MT_MaintenanceItem_SetupDTM MT_MaintenanceItem_Setup { get; set; }
        public bool SaveChange { get; set; }
    }
    public class MT_MaintenanceItem_SetupCreateCommandHandler : IRequestHandler<MT_MaintenanceItem_SetupCreateCommand, RResult>
    {
        private readonly IMT_MaintenanceItem_SetupService mT_MaintenanceItem_SetupService;

        public MT_MaintenanceItem_SetupCreateCommandHandler(IMT_MaintenanceItem_SetupService _mT_MaintenanceItem_SetupService)
        {
            mT_MaintenanceItem_SetupService = _mT_MaintenanceItem_SetupService;
        }
        public async Task<RResult> Handle(MT_MaintenanceItem_SetupCreateCommand request, CancellationToken cancellationToken)
        {
            return await mT_MaintenanceItem_SetupService.SaveMT_MaintenanceItem(request.MT_MaintenanceItem_Setup, request.SaveChange);
        }
    }
}
