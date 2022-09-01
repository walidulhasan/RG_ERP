using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceSchedule_Setups.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceSchedule_Setups.Queries.DataResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.FiniteScheduler.Setup
{
    public interface IMT_MaintenanceSchedule_SetupService
    {
        Task<RResult> SaveSchedule(List<CreateMT_MaintenanceSchedule_SetupDTM> model,CancellationToken cancellationToken=default);
        Task<RResult<ValidateMachineScheduleRM>> ValidateMachineSchedule(string validateData, CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLMachineWiseMaintenanceSchedule(int machineID, CancellationToken cancellationToken);
        Task<List<MachineMaintenanceScheduleRM>> GetMachineMaintenanceSchedule(int machineID, CancellationToken cancellationToken);
    }
}
