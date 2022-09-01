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
    public class Tbl_DivisionRepository : GenericRepository<Tbl_Division>, ITbl_DivisionRepository
    {
        private readonly AlgoHRDBContext dbCon;
        public Tbl_DivisionRepository(AlgoHRDBContext context)
            : base(context)
        {
            dbCon = context;
        }
        public async Task<List<SelectListItem>> DDLDivision(int embroCompanyID, List<int> exceptDivision, string Predict = null, CancellationToken cancellationToken = default)
        {
            var data = await (from d in dbCon.Tbl_Division
                              join c in dbCon.Tbl_Company on d.Division_Company.Value equals c.Cmp_ID
                              where c.EmbroCompanyID == embroCompanyID && (exceptDivision.Count == 0 || !exceptDivision.Contains(d.Division_ID))
                              && (Predict == null || d.Division_Name.Contains(Predict))
                              select new SelectListItem
                              {
                                  Text = d.Division_Name.Trim(),
                                  Value = d.Division_ID.ToString()
                              }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<SelectListItem>> DDLDivision(List<int> embroCompanyID, List<int> exceptDivision, string Predict = null, CancellationToken cancellationToken = default)
        {
            var data = await (from d in dbCon.Tbl_Division
                              join c in dbCon.Tbl_Company on d.Division_Company.Value equals c.Cmp_ID
                              where embroCompanyID.Contains(c.EmbroCompanyID) && (exceptDivision.Count == 0 || !exceptDivision.Contains(d.Division_ID))
                               && (Predict == null || d.Division_Name.Contains(Predict))
                              select new SelectListItem
                              {
                                  Text = d.Division_Name.Trim(),
                                  Value = d.Division_ID.ToString()
                              }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<IdNamePairRM>> DDLDivisionLookUp(List<int> embroCompanyID, List<int> exceptDivision, string Predict = null, CancellationToken cancellationToken = default)
        {
            var dataQuery = from d in dbCon.Tbl_Division
                            join c in dbCon.Tbl_Company on d.Division_Company.Value equals c.Cmp_ID
                            select new {
                                EmbroCompanyID = c.EmbroCompanyID,
                                DivisionName = d.Division_Name,
                                DivisionID = d.Division_ID,
                                CompanyName = c.Cmp_Name
                            };

            if (embroCompanyID.Count > 0)
            {
                dataQuery = dataQuery.Where(b => embroCompanyID.Contains(b.EmbroCompanyID));
            }
            if (exceptDivision.Count > 0)
            {
                dataQuery = dataQuery.Where(w => !exceptDivision.Contains(w.DivisionID));
            }
            dataQuery = dataQuery.Where(w => Predict == null || w.DivisionName.Contains(Predict));

            return await dataQuery.Select(s => new IdNamePairRM
            {
                ID = s.DivisionID,
                Name = s.DivisionName,
                ParentID = s.EmbroCompanyID,
                ParentName = s.CompanyName
            }).ToListAsync(cancellationToken); 
           
        }
    }
}
