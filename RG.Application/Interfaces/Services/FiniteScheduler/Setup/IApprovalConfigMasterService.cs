using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.ApprovalConfigMasters.Commands.Create;
using RG.Application.Contracts.FiniteScheduler.Setups.ApprovalConfigMasters.Queries.RequestResponseModel;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.FiniteScheduler.Setup
{
    public interface IApprovalConfigMasterService
    {
        Task<RResult> SaveApprovalConfigMaster(CreateApprovalConfigMasterDTM model);
     
        Task<List<UserApprovalPowerRM>> GetUserApprovalPower(int designationID, int employeeID, CancellationToken cancellationToken);
        Task<List<ApprovalConfigurationRM>> GetModuleWiseApprovalConfigDetail(ModuleWiseApprovalConfigQM queryModel, CancellationToken cancellationToken);
        
        Task<RResult> RemoveApprovalConfigMasterByDetail(int masterID, int detailID);
       
    }
}
