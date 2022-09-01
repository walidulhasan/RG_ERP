using RG.Application.Contracts.AlgoHR.Business.Tbl_Payroll_Masters.Query.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Business
{
    public class Tbl_Payroll_MasterService : ITbl_Payroll_MasterService
    {
        private readonly ITbl_Payroll_MasterRepository tbl_Payroll_MasterRepository;

        public Tbl_Payroll_MasterService(ITbl_Payroll_MasterRepository _tbl_Payroll_MasterRepository)
        {
            tbl_Payroll_MasterRepository = _tbl_Payroll_MasterRepository;
        }

        public async Task<DateTime?> GetLastSalaryDate(CancellationToken cancellationToken = default)
        {
            try
            {
            var lastRow = await tbl_Payroll_MasterRepository.GetLastRow(x => x.Payroll_ID > 0, o => o.OrderByDescending(d => d.Payroll_ID), cancellationToken);
            if (lastRow!=null)
            {
                return lastRow.Payroll_To;
            }
            else
            {
                return null;
            }


            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<SalaryPaySlipRM> GetSalaryPaySlipInfo(int employeeID, int month, int year, CancellationToken cancellationToken)
        {
            return await tbl_Payroll_MasterRepository.GetSalaryPaySlipInfo(employeeID, month, year, cancellationToken);
        }
    }
}
