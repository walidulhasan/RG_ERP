using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpLeavess.Query.RequestResponseModel;
using RG.Application.Contracts.AlgoHR.Tbl_EmpLeavess.Query.RequestResponseModel;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AlgoHR.Business
{
    public  interface IEmployeeShortLeaveRepository : IGenericRepository<EmployeeShortLeave>
    {
        Task<RResult> EmployeeShortLeaveSave(EmployeeShortLeave entity, bool saveChanges = true);
        Task<List<EmpLeavesRM>> GetShortLeaveApplicationsWaitingForApproval(CancellationToken cancellationToken);
        Task<RResult> UpdateEmployeeShortLeave(EmployeeShortLeave entity);
        Task<List<EmployeeAvailedLeavesRM>> GetEmployeeAvailedLeaves(int employeeID, string employeeCode, DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken);
        Task<List<LeaveHistoryDetailRM>> GetEmployeeLeaveHistoryDetail(LeaveHistoryDetailQM queryModel, CancellationToken cancellationToken);
        Task<List<EmpLeavesEnjoyedRM>> EmpShortLeavesEnjoyed(List<EmpLeavesEnjoyedQM> empWithLeaveType, CancellationToken cancellationToken);
    }
}
