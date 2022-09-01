using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceSchedule_Setups.Queries.DataResponseModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceSchedule_Setups.Queries
{
   public class ValidateMachineScheduleQuery :IRequest<RResult<ValidateMachineScheduleRM>>
    {
        public string Data { get; set; }
    }
    public class ValidateMachineScheduleQueryHandler : IRequestHandler<ValidateMachineScheduleQuery, RResult<ValidateMachineScheduleRM>>
    {
        private readonly IMT_MaintenanceSchedule_SetupService _maintenanceSchedule_SetupService;

        public ValidateMachineScheduleQueryHandler(IMT_MaintenanceSchedule_SetupService maintenanceSchedule_SetupService)
        {
            _maintenanceSchedule_SetupService = maintenanceSchedule_SetupService;
        }
        public async Task<RResult<ValidateMachineScheduleRM>> Handle(ValidateMachineScheduleQuery request, CancellationToken cancellationToken)
        {
            return await _maintenanceSchedule_SetupService.ValidateMachineSchedule(request.Data, cancellationToken);
        }
    }

}
