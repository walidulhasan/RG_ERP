using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.Embro.Business;
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
    public class CBM_ChequeRepository : GenericRepository<CBM_Cheque>, ICBM_ChequeRepository
    {
        private readonly EmbroDBContext _dbCon;

        public CBM_ChequeRepository(EmbroDBContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<List<SelectListItem>> DDLSupplierWhomChequePaidTo(int accountID, DateTime fromDate, DateTime toDate, string predict, CancellationToken cancellationToken)
        {
            var query = _dbCon.CBM_Cheque.Where(x => x.ChqAccountID == accountID && x.ChqDate != null
              && x.ChqDate.Value.Date >= fromDate.Date && x.ChqDate.Value.Date <= toDate)
                .Select(r => new SelectListItem
                {
                    Text = r.ChqDescription.Trim(),
                    Value = r.ChqDescription.Trim()
                }).Distinct();
            if (predict != null)
                query = query.Where(x => x.Text.Contains(predict));

            var data = await query.ToListAsync(cancellationToken);
            return data;
        }
    }
}
