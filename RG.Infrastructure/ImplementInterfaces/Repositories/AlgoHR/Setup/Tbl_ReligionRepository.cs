using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.DBEntities.AlgoHR.Setup;
using RG.Infrastructure.Persistence.AlgoHRDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Setup
{
    public class Tbl_ReligionRepository : GenericRepository<Tbl_Religion>, ITbl_ReligionRepository
    {
        private readonly AlgoHRDBContext _dbCon;
        public Tbl_ReligionRepository(AlgoHRDBContext context)
            : base(context)
        {
            _dbCon = context;
        }
        public async Task<List<SelectListItem>> DDLReligion(CancellationToken cancellationToken)
        {
            var data = await _dbCon.Tbl_Religion
                .Select(x => new SelectListItem
                {
                    Text = x.Religion_Name.Trim(),
                    Value = x.Religion_ID.ToString()
                }).ToListAsync(cancellationToken);
            return data;
        }
    }
}
