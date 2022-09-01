using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Tbl_EmpLeavess.Query.RequestResponseModel;
using RG.Application.ViewModel.AlgoHR.Business.EmployeeShortLeave;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Business
{
    public interface IEmployeeShortLeaveService
    {
        Task<RResult> EmployeeShortLeaveCreate(ShortLeaveCreateVM shortLeave, bool saveChanges = false, CancellationToken cancellationToken = default);
        Task<List<EmployeeAvailedLeavesRM>> GetEmployeeAvailedLeaves(int employeeID, string employeeCode, DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken);
        Task<List<LeaveHistoryDetailRM>> GetEmployeeLeaveHistoryDetail(LeaveHistoryDetailQM queryModel, CancellationToken cancellationToken);
    }
}
