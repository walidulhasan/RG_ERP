using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Setups;
using RG.DBEntities.MaterialsManagement.Setup;
using RG.Infrastructure.Persistence.MaterialsManagementDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.MaterialsManagement.Setups
{
    public class IC_UnitSetupRepository : GenericRepository<IC_UnitSetup>, IIC_UnitSetupRepository
    {
        private readonly MaterialsManagementDBContext dbCon;

        public IC_UnitSetupRepository(MaterialsManagementDBContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }
        public async Task<List<SelectListItem>> DDLGetAllIC_UnitList(List<string> withShortName, CancellationToken cancellationToken)
        {
            var query = dbCon.IC_UnitSetup.Where(x => x.ID > 0);
            if (withShortName!=null && withShortName.Count > 0)
                query = query.Where(x => withShortName.Contains(x.ShortName.Trim()));

            var list = await query.Select(b => new SelectListItem()
            {
                Text = b.Name,
                Value = b.ID.ToString()
            }).ToListAsync( cancellationToken);
            return list;
        }
    }
}
