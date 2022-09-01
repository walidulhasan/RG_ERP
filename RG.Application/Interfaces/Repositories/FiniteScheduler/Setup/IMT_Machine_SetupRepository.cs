using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_Machine_Setups.Queries.RequestResponseModel;
using RG.Application.ViewModel.FiniteScheduler.Setup.MTMachineSetup;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Setup
{
    public interface IMT_Machine_SetupRepository:IGenericRepository<MT_Machine_Setup>
    {
        Task<List<SelectListItem>> DDLLocationWiseMachine(int locationID,CancellationToken cancellationToken);
        Task<RResult> UpdateMachineNextPreventativeDate(int machineID, DateTime currentCheckDate, DateTime nextPreventativeDate, bool saveChange);
        Task<RResult> SaveMachine(MT_Machine_Setup model, bool saveChange);
        //Task<List<MT_Machine_SetupVM>> GetListOfMachine(int companyID, int locationID, int machineGroupID,CancellationToken cancellationToken);
        IQueryable<MachinesRM> GetListOfMachine(int companyID, int locationID, int machineGroupID);
        Task<RResult> UpdateMachine(MT_Machine_Setup model, bool saveChange);
        Task<RResult> CheckDuplicateMachine(string machineName, int machineID=0);
    }
}
