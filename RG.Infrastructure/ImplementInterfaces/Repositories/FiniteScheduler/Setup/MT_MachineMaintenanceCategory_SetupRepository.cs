using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.DBEntities.FiniteScheduler.Setup;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Setup
{
    public class MT_MachineMaintenanceCategory_SetupRepository : GenericRepository<MT_MachineMaintenanceCategory_Setup>, IMT_MachineMaintenanceCategory_SetupRepository
    {
        private FiniteSchedulerDBContext dbCon;
        public MT_MachineMaintenanceCategory_SetupRepository(FiniteSchedulerDBContext context)
            : base(context)
        {
            dbCon = context;
        }
        public async Task<List<SelectListItem>> DDLGetMT_MachineMaintenanceCategory(CancellationToken cancellationToken)
        {
            var rtnList = await dbCon.MT_MachineMaintenanceCategory_Setup.Where(b => b.IsActive == true && b.IsRemoved == false)
                .Select(s => new SelectListItem()
                {
                    Text = s.CategoryName,
                    Value = s.ID.ToString()
                }).ToListAsync();
            return rtnList;
        }
    }
}
