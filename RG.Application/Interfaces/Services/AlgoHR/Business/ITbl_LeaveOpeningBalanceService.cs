using RG.Application.Contracts.AlgoHR.Business.Tbl_LeaveOpeningBalances.Query.RequestResponseModel;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Business
{
    public interface ITbl_LeaveOpeningBalanceService
    {
        Task<List<LeaveOpeningBalanceRM>> GetYearWiseEmployeeLeaveOpeningBalance(string employeeCode, int year, CancellationToken cancellationToken);
    }
}
