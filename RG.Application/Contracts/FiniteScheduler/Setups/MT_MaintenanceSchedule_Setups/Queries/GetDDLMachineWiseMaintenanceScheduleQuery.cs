using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceSchedule_Setups.Queries
{
    public class GetDDLMachineWiseMaintenanceScheduleQuery:IRequest<List<SelectListItem>>
    {
        public int MachineID { get; set; }
    }
    public class GetDDLMachineWiseMaintenanceScheduleQueryHandler : IRequestHandler<GetDDLMachineWiseMaintenanceScheduleQuery, List<SelectListItem>>
    {
        private readonly IMT_MaintenanceSchedule_SetupService mT_MaintenanceSchedule_SetupService;

        public GetDDLMachineWiseMaintenanceScheduleQueryHandler(IMT_MaintenanceSchedule_SetupService _mT_MaintenanceSchedule_SetupService)
        {
            mT_MaintenanceSchedule_SetupService = _mT_MaintenanceSchedule_SetupService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLMachineWiseMaintenanceScheduleQuery request, CancellationToken cancellationToken)
        {
            return await mT_MaintenanceSchedule_SetupService.DDLMachineWiseMaintenanceSchedule(request.MachineID, cancellationToken);
        }
    }
}
