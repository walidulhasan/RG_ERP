using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.Embro.Business;
using RG.Application.ViewModel.Embro.Business.LoanMasters;
using RG.DBEntities.Embro.Business;
using RG.Infrastructure.Persistence.EmbroDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Embro.Business
{
    public class LoanInstallmentRepository : GenericRepository<LoanInstallment>, ILoanInstallmentRepository
    {
        private readonly EmbroDBContext _dbCon;

        public LoanInstallmentRepository(EmbroDBContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<List<LoanInstallmentVM>> LoanInstallmentEdit(int id, CancellationToken cancellationToken)
        {
            var model = await (from li in _dbCon.LoanInstallment
                               join lm in _dbCon.LoanMaster on li.LoanID equals lm.LoanID
                               where li.LoanID == id && li.IsActive == true && li.IsRemoved == false
                               select new LoanInstallmentVM
                               {
                                   LoanInstallmentID = li.LoanInstallmentID,
                                   InstallmentNo = li.InstallmentNo,
                                   InstallmentDate = li.InstallmentDate,
                                   InstallmentAmount = li.InstallmentAmount,
                                   InterestAmount = li.InterestAmount,
                               }).ToListAsync(cancellationToken);
            return model;
        }
    }
}
