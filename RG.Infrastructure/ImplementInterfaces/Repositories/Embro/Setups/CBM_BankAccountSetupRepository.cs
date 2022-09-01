using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.DBEntities.Embro.Setup;
using RG.Infrastructure.Persistence.EmbroDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Embro.Setups
{
    public class CBM_BankAccountSetupRepository : GenericRepository<CBM_BankAccountSetup>, ICBM_BankAccountSetupRepository
    {
        private readonly EmbroDBContext _dbCon;

        public CBM_BankAccountSetupRepository(EmbroDBContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<List<SelectListItem>> DDLCBM_BankAccount(int bankID, string predict, CancellationToken cancellationToken)
        {
            var query = from ba in _dbCon.CBM_BankAccountSetup
                       join bb in _dbCon.CBM_Branch on ba.BranchID equals bb.BranchID
                       join b in _dbCon.CBM_Bank on bb.BankID equals b.BankID
                       where b.BankID == bankID
                       select new SelectListItem {
                           Text = ba.BAccountName.Trim(),
                           Value = ba.BAccountID.ToString()
                       };
            if (predict != null)
                query = query.Where(x => x.Text.Contains(predict));

            return await query.ToListAsync(cancellationToken);
        }
    }
}
