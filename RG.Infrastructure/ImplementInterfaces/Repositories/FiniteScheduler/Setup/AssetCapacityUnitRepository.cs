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
    public class AssetCapacityUnitRepository : GenericRepository<AssetCapacityUnit>, IAssetCapacityUnitRepository
    {
        private readonly FiniteSchedulerDBContext _dbCon;
        public AssetCapacityUnitRepository(FiniteSchedulerDBContext context) : base(context)
        {
            _dbCon = context;
        }
        public async Task<List<SelectListItem>> DDLAssetCapacityUnit(CancellationToken cancellationToken)
        {
            var data = await _dbCon.AssetCapacityUnit.Where(x => x.IsActive == true && x.IsRemoved == false)
                .Select(r => new SelectListItem()
                {
                    Text = r.CapacityUnitName,
                    Value = r.CapacityUnitID.ToString()
                }).ToListAsync(cancellationToken);
            return data;
        }
    }
}
