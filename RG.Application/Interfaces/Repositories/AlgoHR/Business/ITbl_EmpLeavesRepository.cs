using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpLeavess.Query.RequestResponseModel;
using RG.Application.Contracts.AlgoHR.Tbl_EmpLeavess.Query.RequestResponseModel;
using RG.DBEntities.AlgoHR.Business;
using RG.DBEntities.AlgoHR.DBViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AlgoHR.Business
{
    public interface ITbl_EmpLeavesRepository : IGenericRepository<Tbl_EmpLeaves>
    {
        Task<RResult> SaveTbl_EmpLeaves(Tbl_EmpLeaves entity, bool saveChange = true);
        Task<RResult> UpdateTbl_EmpLeaves(Tbl_EmpLeaves entity, bool saveChange = true);
        Task<RResult> DeleteTbl_EmpLeaves(int leaveID, bool saveChange = true);
        Task<List<EmployeeAvailedLeavesRM>> GetEmployeeAvailedLeaves(int employeeID, string employeeCode, DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken);
        Task<List<EmpLeavesRM>> GetLeaveApplicationsWaitingForApproval(CancellationToken cancellationToken);
        Task<List<LeaveHistoryDetailRM>> GetEmployeeLeaveHistoryDetail(LeaveHistoryDetailQM queryModel, CancellationToken cancellationToken);
        Task<List<EmpLeavesEnjoyedRM>> EmpLeavesEnjoyed(List<EmpLeavesEnjoyedQM> queryModel, CancellationToken cancellationToken);
        Task<List<SearchedLeaveListRM>>SearchedLeaveList(int leaveID, string leaveStatus, DateTime dateFrom, DateTime dateTo, int companyID, int divisionID, int departmentID, CancellationToken cancellationToken);
        Task<Vw_EmpLeaves> GetEmpLeaveInfo(int leaveApplicationID, CancellationToken cancellationToken);
        Task<List<LeaveHistoryDetailInfoRM>> GetEmployeeLeaveHistoryDetailInfo(LeaveHistoryDetailInfoQM queryModel, CancellationToken cancellationToken);


    }
}
