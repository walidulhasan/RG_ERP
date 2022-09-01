using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Queries.RequestResponseModel;
using RG.DBEntities.AlgoHR.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Setup
{
    public interface IApprovalConfigMasterService
    {
        Task<RResult> SaveApprovalConfigMaster(CreateApprovalConfigMasterDTM model);

        Task<List<UserApprovalPowerRM>> GetUserApprovalPower(int designationID, int employeeID, CancellationToken cancellationToken);
        Task<List<ApprovalConfigurationRM>> GetModuleWiseApprovalConfigDetail(ModuleWiseApprovalConfigQM queryModel, CancellationToken cancellationToken);
        Task<ApprovalConfigMaster> GetEmployeeModuleWiseApprovalConfig(ModuleWiseApprovalConfigQM queryModel, CancellationToken cancellationToken = default);
        Task<RResult> RemoveApprovalConfigMasterByDetail(int masterID, int detailID);
        Task<RResult> ReplaceApprover(UpdateReplaceApproverDTM replaceApprover, CancellationToken cancellationToken);
    }
}
