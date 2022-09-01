using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.DBEntities.MaterialsManagement;
using RG.Infrastructure.Persistence.MaterialsManagementDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.MaterialsManagement.Business
{
    public class Yarn_POMasterRepository : GenericRepository<Yarn_POMaster>, IYarn_POMasterRepository
    {
        private readonly MaterialsManagementDBContext dbCon;

        public Yarn_POMasterRepository(MaterialsManagementDBContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }
        public async Task<List<SelectListItem>> DDLYarnPONo(int supplierID, DateTime poDateFrom, DateTime poDateTo, string predict = null, CancellationToken cancellationToken = default)
        {
            var query = dbCon.Yarn_POMaster
                 .Where(x => x.SupplierID == supplierID && x.PODate >= poDateFrom && x.PODate <= poDateTo)
                 .Select(r => new SelectListItem
                 {
                     Text = r.YarnPONo,
                     Value = r.Yarn_POID.ToString()
                 });
             if(!string.IsNullOrWhiteSpace(predict))
            {
                query = query.Where(b => b.Text.Contains(predict));
            }
                var data = await query.ToListAsync(cancellationToken);
            return data;
        }
    }
}
