using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.DBEntities.AlgoHR.Setup;
using RG.Infrastructure.Persistence.AlgoHRDB;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Setup
{
    public class Tbl_LocationRepository : GenericRepository<Tbl_Location>, ITbl_LocationRepository
    {
        private readonly AlgoHRDBContext _dbCon;

        public Tbl_LocationRepository(AlgoHRDBContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }

        public async Task<List<SelectListItem>> DDLLocation(List<int> CompanyID, string Predict = null, CancellationToken cancellationToken = default)
        {
            var query = from l in _dbCon.Tbl_Location
                        join c in _dbCon.Tbl_Company on l.Location_Company equals c.Cmp_ID into lc
                        from _l in lc.DefaultIfEmpty()
                        select new
                        {
                            CompanyID = _l == null ? 0 : _l.EmbroCompanyID,
                            LocationID = l.Location_Id,
                            LocationName = l.Location_Name,
                        };
            if (CompanyID.Count > 0)
            {
                query = query.Where(s => (s.CompanyID == 0 || CompanyID.Contains(s.CompanyID)));
            }
            return await query
                .Where(w=> (Predict==null || w.LocationName.StartsWith(Predict)))
                .Select(s => new SelectListItem()
                {
                    Text = s.LocationName,
                    Value = s.LocationID.ToString()
                })
                .ToListAsync(cancellationToken);
        }
    }
}
