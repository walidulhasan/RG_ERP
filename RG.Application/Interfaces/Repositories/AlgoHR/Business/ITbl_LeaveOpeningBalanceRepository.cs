using RG.DBEntities.AlgoHR;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AlgoHR.Business
{
    public interface ITbl_LeaveOpeningBalanceRepository:IGenericRepository<Tbl_LeaveOpeningBalance>
    {
        Task<List<Tbl_LeaveOpeningBalance>> GetYearWiseEmployeeLeaveOpeningBalance(string employeeCode, int year, CancellationToken cancellationToken);
    }
}
