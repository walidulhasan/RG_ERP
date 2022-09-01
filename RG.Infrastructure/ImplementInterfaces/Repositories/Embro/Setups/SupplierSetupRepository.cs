using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.DBEntities.Embro.Setup;
using RG.Infrastructure.Persistence.EmbroDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Embro.Setups
{
    public class SupplierSetupRepository : GenericRepository<SupplierSetup>, ISupplierSetupRepository
    {
        private readonly EmbroDBContext dbCon;
        public SupplierSetupRepository(EmbroDBContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }
        public async Task<List<SelectListItem>> DDLGetSupplierList(int companyID, List<int> AccCategoryID = null, List<int> NotInSupplier = null, string Predict = null, CancellationToken cancellationToken = default)
        {
            var supplierQry = from bc in dbCon.BasicCOA
                              join bc1 in dbCon.BasicCOA on (int)bc.ParentID equals bc1.ID
                              join bc2 in dbCon.BasicCOA on (int)bc1.ParentID equals bc2.ID
                              join bc3 in dbCon.BasicCOA on (int)bc2.ParentID equals bc3.ID
                              join bc4 in dbCon.BasicCOA on (int)bc3.ParentID equals bc4.ID
                              join bc5 in dbCon.BasicCOA on (int)bc4.ParentID equals bc5.ID
                              join bc6 in dbCon.BasicCOA on (int)bc5.ParentID equals bc6.ID
                              join _ss in dbCon.SupplierSetup on bc.ID equals _ss.ID  into ssLeft
                              from ss in ssLeft.DefaultIfEmpty()
                              where bc.Status == 0 && bc.DESCRIPTION.Length > 0
                              //&& (AccCategoryID == 0 || (int)bc5.ID == AccCategoryID)
                              //&& (companyID == 0 || bc5.ParentID == companyID) || (bc5.ParentID == 183 || bc5.ParentID == 20183)
                              select new
                              {
                                  AccCategoryID=(int)bc5.ID,
                                  CompanyID = bc5.ParentID.Value,
                                  SupplierID = (int)bc.ID,
                                  SupplierName = bc.DESCRIPTION.Trim(),
                                  Group1 = bc5.DESCRIPTION.Trim(),
                                  Group2 = bc4.DESCRIPTION.Trim(),
                                  Group3 = bc3.DESCRIPTION.Trim(),
                                  comShort = bc6.ID == 183 ? "RBL" : "CBL",
                                  GroupName = string.Join("=>", bc5.DESCRIPTION.Trim(), bc4.DESCRIPTION.Trim(), bc3.DESCRIPTION.Trim())
                              };
            if (companyID > 0)
            {
                supplierQry = supplierQry.Where(b => b.CompanyID == companyID);
            }

            if (AccCategoryID!=null && AccCategoryID.Count() > 0)
            {
                var cagegoryNotZero = AccCategoryID.Where(b => b > 0).ToList();
                supplierQry = supplierQry.Where(b => cagegoryNotZero.Contains(b.AccCategoryID));
            }
            if (NotInSupplier!=null && NotInSupplier.Count > 0)
            {
                supplierQry = supplierQry.Where(b => !NotInSupplier.Contains((b.SupplierID)));
            }
            if (Predict != null)
            {
                supplierQry = supplierQry.Where(b => b.SupplierName.Contains(Predict));
            }
            var group = await supplierQry
                          .Select(g =>g.GroupName)
                          .Distinct()
                          .Select(gn => new SelectListGroup() { Name = gn })
                          .ToDictionaryAsync(gp => gp.Name, StringComparer.Ordinal, cancellationToken);

            var data = await supplierQry.Select(s => new SelectListItem
            {
                Text = $"{s.SupplierName}",
                Value = s.SupplierID.ToString(),
                Group = group[s.GroupName]
            }).ToListAsync(cancellationToken);
            return data;
        }
        public async Task<List<SelectListItem>> DDLSuppliers(int companyID, List<int> AccCategoryID = null, List<int> NotInSupplier = null, string Predict = null, CancellationToken cancellationToken = default)
        {
            var supplierQry = from bc in dbCon.BasicCOA
                              join bc1 in dbCon.BasicCOA on (int)bc.ParentID equals bc1.ID
                              join bc2 in dbCon.BasicCOA on (int)bc1.ParentID equals bc2.ID
                              join bc3 in dbCon.BasicCOA on (int)bc2.ParentID equals bc3.ID
                              join bc4 in dbCon.BasicCOA on (int)bc3.ParentID equals bc4.ID
                              join bc5 in dbCon.BasicCOA on (int)bc4.ParentID equals bc5.ID
                              join bc6 in dbCon.BasicCOA on (int)bc5.ParentID equals bc6.ID
                              join _ss in dbCon.SupplierSetup on bc.ID equals _ss.ID                               
                              where bc.Status == 0 && bc.DESCRIPTION.Length > 0
                              select new
                              {
                                  AccCategoryID = (int)bc5.ID,
                                  CompanyID = bc5.ParentID.Value,
                                  SupplierID = (int)bc.ID,
                                  SupplierName = bc.DESCRIPTION.Trim(),
                                  Group1 = bc5.DESCRIPTION.Trim(),
                                  Group2 = bc4.DESCRIPTION.Trim(),
                                  Group3 = bc3.DESCRIPTION.Trim(),
                                  comShort = bc6.ID == 183 ? "RBL" : "CBL",
                                  GroupName = string.Join("=>", bc5.DESCRIPTION.Trim(), bc4.DESCRIPTION.Trim(), bc3.DESCRIPTION.Trim())
                              };
            if (companyID > 0)
            {
                supplierQry = supplierQry.Where(b => b.CompanyID == companyID);
            }
            if (AccCategoryID != null && AccCategoryID.Count() > 0)
            {
                var cagegoryNotZero = AccCategoryID.Where(b => b > 0).ToList();
                supplierQry = supplierQry.Where(b => cagegoryNotZero.Contains(b.AccCategoryID));
            }
            if (NotInSupplier != null && NotInSupplier.Count > 0)
            {
                supplierQry = supplierQry.Where(b => !NotInSupplier.Contains((b.SupplierID)));
            }
            if (Predict != null)
            {
                supplierQry = supplierQry.Where(b => b.SupplierName.Contains(Predict));
            }
            var group = await supplierQry
                          .Select(g => g.GroupName)
                          .Distinct()
                          .Select(gn => new SelectListGroup() { Name = gn })
                          .ToDictionaryAsync(gp => gp.Name, StringComparer.Ordinal, cancellationToken);

            var data = await supplierQry.Select(s => new SelectListItem
            {
                Text = $"{s.SupplierName}",
                Value = s.SupplierID.ToString(),
                Group = group[s.GroupName]
            }).ToListAsync(cancellationToken);
            return data;
        }
    }
}
