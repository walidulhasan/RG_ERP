using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.CommonInterfaces;
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
    public class CBM_BankRepository : GenericRepository<CBM_Bank>, ICBM_BankRepository
    {
        private readonly EmbroDBContext _dbCon;
        private readonly ICurrentUserService _currentUserService;

        public CBM_BankRepository(EmbroDBContext dbCon, ICurrentUserService currentUserService) : base(dbCon)
        {
            _dbCon = dbCon;
            _currentUserService = currentUserService;
        }
        public async Task<List<SelectListItem>> DDLCBM_Bank(int CompanyID=0,string predict=null, CancellationToken cancellationToken=default)
        {
            var dbQuery = _dbCon.CBM_Bank.Where(x => x.BankStatus != 95);
            if (CompanyID == 0)
            {
                dbQuery = dbQuery.Where(b => b.CompanyID == _currentUserService.CompanyID);
            }
            else
            {
                dbQuery = dbQuery.Where(b => b.CompanyID == CompanyID);
            }

             var query = dbQuery.Select(r => new SelectListItem
                {
                    Text = r.BankName.Trim(),
                    Value = r.BankID.ToString()
                });
            if (predict != null)
                query = query.Where(x => x.Text.Contains(predict));

            var data = await query.ToListAsync(cancellationToken);
            return data;
        }
    }
}
