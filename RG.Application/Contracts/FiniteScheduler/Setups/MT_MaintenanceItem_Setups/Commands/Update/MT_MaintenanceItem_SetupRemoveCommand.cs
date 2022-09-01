using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceItem_Setups.Commands.Update
{
    public class MT_MaintenanceItem_SetupRemoveCommand : IRequest<RResult>
    {
        public int ItemID { get; set; }
    }
    public class MT_MaintenanceItem_SetupRemoveCommandHandler : IRequestHandler<MT_MaintenanceItem_SetupRemoveCommand, RResult>
    {
        private readonly IMT_MaintenanceItem_SetupService _mT_MaintenanceItem_SetupService;

        public MT_MaintenanceItem_SetupRemoveCommandHandler(IMT_MaintenanceItem_SetupService mT_MaintenanceItem_SetupService)
        {
            _mT_MaintenanceItem_SetupService = mT_MaintenanceItem_SetupService;
        }
        public async Task<RResult> Handle(MT_MaintenanceItem_SetupRemoveCommand request, CancellationToken cancellationToken)
        {
            return await _mT_MaintenanceItem_SetupService.RemoveMaintenanceItem(request.ItemID, true);
        }
    }
}
