using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Utilities;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.DBEntities.AlgoHR.Setup;
using RG.Infrastructure.Persistence.AlgoHRDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Setup
{
    public class Tbl_SectionRepository : GenericRepository<Tbl_Section>, ITbl_SectionRepository
    {
        private readonly AlgoHRDBContext _dbCon;
        public Tbl_SectionRepository(AlgoHRDBContext context)
            : base(context)
        {
            _dbCon = context;
        }

        public async Task<List<SelectListItem>> DDLSection(int departmentID, CancellationToken cancellationToken = default)
        {
            var data = await _dbCon.Tbl_Section.Where(x => x.Section_Dept == departmentID)
                        .Select(row => new SelectListItem()
                        {
                            Text = row.Section_Name.Trim(),
                            Value = row.Section_Id.ToString()
                        }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<SelectListItem>> DDLSection(List<int> departmentID, string Predict = null, CancellationToken cancellationToken = default)
        {
            var data = await _dbCon.Tbl_Section.Where(x => departmentID.Contains(x.Section_Dept.Value)
                    && (Predict == null || x.Section_Name.StartsWith(Predict)))
                     .Select(row => new SelectListItem()
                     {
                         Text = row.Section_Name.Trim(),
                         Value = row.Section_Id.ToString()
                     }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<IdNamePairRM>> DDLSectionLookup(List<int> departmentID, string Predict = null, CancellationToken cancellationToken = default)
        {
            var query = from dep in _dbCon.Tbl_Dept
                        join sec in _dbCon.Tbl_Section on dep.Dept_ID equals sec.Section_Dept
                        select new IdNamePairRM
                        {
                            ID = sec.Section_Id,
                            Name = sec.Section_Name,
                            ParentID = dep.Dept_ID,
                            ParentName = dep.Dept_Name
                        };
            if (departmentID.Count > 0)
            {
                query = query.Where(b => departmentID.Contains(b.ParentID));
            }
            if (!string.IsNullOrEmpty(Predict))
            {
                query = query.Where(w => Predict.Contains(w.Name));
            }
            return await query.ToListAsync(cancellationToken);
        }
    }
}
