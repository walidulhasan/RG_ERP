using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.ApprovalConfigMasters.Queries.RequestResponseModel;
using RG.DBEntities.FiniteScheduler.Business;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Setup
{
    public interface IApprovalConfigMasterRepository : IGenericRepository<ApprovalConfigMaster>
    {
        Task<RResult> SaveApprovalConfigMaster(ApprovalConfigMaster model);

        Task<RResult> UpdateApprovalConfigMaster(ApprovalConfigMaster model);
        Task<ApprovalConfigMaster> GetModuleWiseApprovalConfig(int configMasterID, CancellationToken cancellationToken = default);
        Task<ApprovalConfigMaster> GetModuleWiseApprovalConfig(ModuleWiseApprovalConfigQM queryModel, CancellationToken cancellationToken=default);
        Task<List<ApprovalConfigMaster>> GetEmployeeModuleWiseApprovalConfig(ModuleWiseApprovalConfigQM queryModel, CancellationToken cancellationToken = default);

        Task<List<UserApprovalPowerRM>> GetUserApprovalPower(int designationID, int employeeID, CancellationToken cancellationToken=default);
        Task<RResult> RemoveApprovalConfigMasterByDetail(int masterID, int detailID, int updatedBy);
        Task<RResult> SaveApprovalConfigDetail(List<ApprovalConfigDetail> model);
   
    }
}
