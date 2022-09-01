using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpLeavess.Query.RequestResponseModel;
using RG.Application.Contracts.AlgoHR.Tbl_EmpLeavess.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Tbl_EmpLeavess.Query.RequestResponseModel;
using RG.Application.ViewModel.AlgoHR.Business.EmployeeLeaveCancel;
using RG.DBEntities.AlgoHR.DBViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Business
{
    public interface ITbl_EmpLeavesService
    {
        Task<RResult> SaveTbl_EmpLeaves(EmpLeaveDTM model, bool saveChange = true);
        Task<RResult> DeleteTbl_EmpLeaves(int leaveID, int leaveTypeID,bool saveChange = true);
        Task<RResult> AdjustTbl_EmpLeaves(int leaveID, DateTime AdjustedDateFrom, DateTime AdjustedDateTo, bool saveChange = true);
        Task<List<EmployeeAvailedLeavesRM>> GetEmployeeAvailedLeaves(int employeeID,string employeeCode, DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken);
        Task<RResult> ApprovedLeaveApplicationAdjust(EmployeeLeaveCancelVM leaveAdjust, CancellationToken cancellationToken);
        Task<List<LeaveHistoryDetailRM>> GetEmployeeLeaveHistoryDetail(LeaveHistoryDetailQM queryModel, CancellationToken cancellationToken);
        Task<List<SearchedLeaveListRM>> SearchedLeaveList(int leaveID, string leaveStatus, DateTime dateFrom, DateTime dateTo, int companyID, int divisionID, int departmentID, CancellationToken cancellationToken);
        Task<Vw_EmpLeaves> GetEmpLeaveInfo(int leaveApplicationID, CancellationToken cancellationToken);
        Task<RResult> EmpLeaveApprovedFalse(int id, string Commant, string status, bool saveChanges= true);
        Task<RResult> ApplicationCancel(EmployeeLeaveCancelVM employeeLeaveCancelVM, CancellationToken cancellationToken);
        Task<List<LeaveHistoryDetailInfoRM>> GetEmployeeLeaveHistoryDetailInfo(LeaveHistoryDetailInfoQM queryModel, CancellationToken cancellationToken);

    }
}
