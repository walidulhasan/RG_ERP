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
    public class Tbl_DeptRepository : GenericRepository<Tbl_Dept>, ITbl_DeptRepository
    {
        private readonly AlgoHRDBContext dbCon;
        public Tbl_DeptRepository(AlgoHRDBContext context)
            : base(context)
        {
            dbCon = context;
        }

        public async Task<List<IdNamePairRM>> DDLDepartmentLookup(List<int> divisionID, string Predict = null, CancellationToken cancellationToken = default)
        {
            var query = from div in dbCon.Tbl_Division
                        join dep in dbCon.Tbl_Dept on div.Division_ID equals dep.Dept_Division
                        select new IdNamePairRM
                        {
                            ID = dep.Dept_ID,
                            Name = dep.Dept_Name,
                            ParentID = div.Division_ID,
                            ParentName = div.Division_Name
                        };
            if (divisionID.Count > 0)
            {
                query = query.Where(w => divisionID.Contains(w.ParentID));
            }
            if (!string.IsNullOrEmpty(Predict))
            {
                query = query.Where(w => Predict.Contains(w.Name));
            }
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLDept(int divisionID, CancellationToken cancellationToken = default)
        {
            var data = await dbCon.Tbl_Dept.Where(x => x.Dept_Division == divisionID)
                              .Select(row => new SelectListItem
                              {
                                  Text = row.Dept_Name.Trim(),
                                  Value = row.Dept_ID.ToString()
                              }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<SelectListItem>> DDLDept(List<int> divisionID, string Predict = null, CancellationToken cancellationToken = default)
        {
            var data = await dbCon.Tbl_Dept.Where(x => divisionID.Contains(x.Dept_Division.Value)
                && Predict == null || x.Dept_Name.Contains(Predict))
                .Select(row => new SelectListItem
                {
                    Text = row.Dept_Name.Trim(),
                    Value = row.Dept_ID.ToString()
                }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<SelectListItem>> DDLDeptListOnly(CancellationToken cancellationToken)
        {
            var data = dbCon.Tbl_Dept.Select(x => new SelectListItem
            {
                Text=x.Dept_Name.ToString(),
                Value=x.Dept_ID.ToString()
            });
            return await data.ToListAsync(cancellationToken);
        }
    }
}
