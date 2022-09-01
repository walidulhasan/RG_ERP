using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceSchedule_Setups.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceSchedule_Setups.Queries.DataResponseModel;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Setup
{
    public interface IMT_MaintenanceSchedule_SetupRepository:IGenericRepository<MT_MaintenanceSchedule_Setup>
    {
        Task<RResult<ValidateMachineScheduleRM>> ValidateMachineSchedule(string validateData,CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLMachineWiseMaintenanceSchedule(int machineID, CancellationToken cancellationToken);
        Task<RResult> UpdateMaintenanceSchedule(MT_MaintenanceSchedule_Setup entity,bool saveChange=true);
        Task<List<MachineMaintenanceScheduleRM>> GetMachineMaintenanceSchedule(int machineID, CancellationToken cancellationToken);


    }
}
