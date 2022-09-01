using RG.Application.Contracts.AlgoHR.Business.Tbl_Payroll_Masters.Query.RequestResponseModel;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AlgoHR.Business
{
    public interface ITbl_Payroll_MasterRepository:IGenericRepository<Tbl_Payroll_Master>
    {
        Task<SalaryPaySlipRM> GetSalaryPaySlipInfo(int employeeID, int month, int year, CancellationToken cancellationToken);
    }
}
