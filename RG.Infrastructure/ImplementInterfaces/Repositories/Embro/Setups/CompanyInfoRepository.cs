using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.DBEntities.Embro.Setup;
using RG.Infrastructure.Persistence.EmbroDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Embro.Setups
{
    public class CompanyInfoRepository : GenericRepository<CompanyInfo>, ICompanyInfoRepository
    {
        private readonly EmbroDBContext dbCon;

        public CompanyInfoRepository(EmbroDBContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }
        public async Task<List<SelectListItem>> DDLCompany(CancellationToken cancellationToken)
        {
            var data = await dbCon.CompanyInfo.Where(s => s.CompanyID != 3684).Select(x => new SelectListItem
            {
                Text = x.Companyname,
                Value = x.CompanyID.ToString()
            }).ToListAsync();
            return data;
        }
    }
}
