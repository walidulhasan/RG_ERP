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
    public class MT_MachineGroupRepository : GenericRepository<MT_MachineGroup>, IMT_MachineGroupRepository
    {
        private readonly FiniteSchedulerDBContext dbCon;
        public MT_MachineGroupRepository(FiniteSchedulerDBContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }
        public async Task<List<SelectListItem>> GetDDLMachineGroup(CancellationToken cancellationToken)
        {
            var data = await dbCon.MT_MachineGroup.Where(x => x.IsActive == true && x.IsRemoved == false)
                .Select(r => new SelectListItem
                {
                    Text=r.MachineGroup,
                    Value=r.ID.ToString()
                }).ToListAsync();
            return data;
        }
    }
}
