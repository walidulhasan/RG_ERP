using RG.Application.ViewModel.Embro.Business.LoanMasters;
using RG.DBEntities.Embro.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Embro.Business
{
    public interface ILoanInstallmentRepository :IGenericRepository<LoanInstallment>
    {
        Task<List<LoanInstallmentVM>> LoanInstallmentEdit(int id, CancellationToken cancellationToken);
    }
}
