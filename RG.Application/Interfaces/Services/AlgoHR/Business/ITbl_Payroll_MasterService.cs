using RG.Application.Contracts.AlgoHR.Business.Tbl_Payroll_Masters.Query.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Business
{
    public interface ITbl_Payroll_MasterService
    {
        Task<SalaryPaySlipRM> GetSalaryPaySlipInfo(int employeeID, int month, int year, CancellationToken cancellationToken);
        Task<DateTime?> GetLastSalaryDate(CancellationToken cancellationToken = default);
    }
}
