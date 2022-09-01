using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_Machine_Setups.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_Machine_Setups.Queries.RequestResponseModel;
using RG.Application.ViewModel.FiniteScheduler.Setup.MTMachineSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.FiniteScheduler.Setup
{
    public interface IMT_Machine_SetupService
    {
        Task<List<SelectListItem>> DDLLocationWiseMachine(int locationID, CancellationToken cancellationToken);
        Task<RResult> SaveMachine(MT_Machine_SetupDTM model, bool saveChange);
        //Task<List<MT_Machine_SetupVM>> GetListOfMachine( int companyID, int locationID, int machineGroupID,CancellationToken cancellationToken);
        IQueryable<MachinesRM> GetListOfMachine(int companyID, int locationID, int machineGroupID);
        
        Task<RResult> UpdateMachine(MT_Machine_SetupDTM model, bool saveChange);
        Task<RResult> RemoveMachine(int machineID, bool saveChange);
    }
}
