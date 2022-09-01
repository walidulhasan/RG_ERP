using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.DBEntities.AlgoHR.Setup;
using RG.Infrastructure.Persistence.AlgoHRDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Setup
{
    public class Tbl_CountryRepository : GenericRepository<Tbl_Country>, ITbl_CountryRepository
    {
        private readonly AlgoHRDBContext _context;

        public Tbl_CountryRepository(AlgoHRDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<SelectListItem>> DDLGetOnlyCountryList(CancellationToken cancellationToken)
        {
            var list = await _context.Tbl_Country
                    .Select(b => new SelectListItem()
                    {
                        Text = b.Country_CName,
                        Value = b.Country_CID
                    }).OrderBy(o => o.Text).ToListAsync();
            return list;
        }

    }
}
