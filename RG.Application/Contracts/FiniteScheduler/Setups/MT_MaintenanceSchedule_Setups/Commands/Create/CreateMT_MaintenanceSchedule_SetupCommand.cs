using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceSchedule_Setups.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceSchedule_Setups.Commands.Create
{
    public class CreateMT_MaintenanceSchedule_SetupCommand : IRequest<RResult>
    {
        public List<CreateMT_MaintenanceSchedule_SetupDTM> MT_MaintenanceSchedule_Setup { get; set; }
    }

    public class CreateMT_MaintenanceSchedule_SetupCommandHandler : IRequestHandler<CreateMT_MaintenanceSchedule_SetupCommand, RResult>
    {
        private readonly IMT_MaintenanceSchedule_SetupService _maintenanceSchedule_SetupService;

        public CreateMT_MaintenanceSchedule_SetupCommandHandler(IMT_MaintenanceSchedule_SetupService maintenanceSchedule_SetupService)
        {
            _maintenanceSchedule_SetupService = maintenanceSchedule_SetupService;
        }
        public async Task<RResult> Handle(CreateMT_MaintenanceSchedule_SetupCommand request, CancellationToken cancellationToken)
        {
            return await _maintenanceSchedule_SetupService.SaveSchedule(request.MT_MaintenanceSchedule_Setup,cancellationToken);
        }
    }
}
