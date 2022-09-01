using MediatR;
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
    public class GetMachineMaintenanceScheduleQuery:IRequest<List<MachineMaintenanceScheduleRM>>
    {
        public int MachineID { get; set; }
    }
    public class GetMachineMaintenanceScheduleQueryHandler : IRequestHandler<GetMachineMaintenanceScheduleQuery, List<MachineMaintenanceScheduleRM>>
    {
        private readonly IMT_MaintenanceSchedule_SetupService mT_MaintenanceSchedule_SetupService;

        public GetMachineMaintenanceScheduleQueryHandler(IMT_MaintenanceSchedule_SetupService _mT_MaintenanceSchedule_SetupService)
        {
            mT_MaintenanceSchedule_SetupService = _mT_MaintenanceSchedule_SetupService;
        }
        public async Task<List<MachineMaintenanceScheduleRM>> Handle(GetMachineMaintenanceScheduleQuery request, CancellationToken cancellationToken)
        {
            return await mT_MaintenanceSchedule_SetupService.GetMachineMaintenanceSchedule(request.MachineID, cancellationToken);
        }
    }
}
