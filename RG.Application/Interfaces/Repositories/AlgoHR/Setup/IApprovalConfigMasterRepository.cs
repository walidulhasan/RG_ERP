using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Queries.RequestResponseModel;
using RG.DBEntities.AlgoHR.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AlgoHR.Setup
{
    public interface IApprovalConfigMasterRepository : IGenericRepository<ApprovalConfigMaster>
    {
        Task<RResult> SaveApprovalConfigMaster(ApprovalConfigMaster model);

        Task<RResult> UpdateApprovalConfigMaster(ApprovalConfigMaster model);
        Task<ApprovalConfigMaster> GetModuleWiseApprovalConfig(int configMasterID, CancellationToken cancellationToken = default);
        Task<ApprovalConfigMaster> GetModuleWiseApprovalConfig(ModuleWiseApprovalConfigQM queryModel, CancellationToken cancellationToken = default);
        Task<List<ApprovalConfigMaster>> GetEmployeeModuleWiseApprovalConfig(ModuleWiseApprovalConfigQM queryModel, CancellationToken cancellationToken = default);

        Task<List<UserApprovalPowerRM>> GetUserApprovalPower(int designationID, int employeeID, CancellationToken cancellationToken = default);
        Task<RResult> RemoveApprovalConfigMasterByDetail(int masterID, int detailID, int updatedBy);
        Task<RResult> SaveApprovalConfigDetail(List<ApprovalConfigDetail> model);
        Task<RResult> ReplaceApprover(UpdateReplaceApproverDTM replaceApprover, CancellationToken cancellationToken);
    }
}
