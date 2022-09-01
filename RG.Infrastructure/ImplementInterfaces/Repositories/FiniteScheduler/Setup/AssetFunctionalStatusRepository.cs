using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.DBEntities.FiniteScheduler.Setup;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Setup
{
    public class AssetFunctionalStatusRepository : GenericRepository<AssetFunctionalStatus>, IAssetFunctionalStatusRepository
    {
        private readonly FiniteSchedulerDBContext _dbCon;
        public AssetFunctionalStatusRepository(FiniteSchedulerDBContext context) : base(context)
        {
            _dbCon = context;
        }
        public async Task<List<SelectListItem>> DDLAssetFunctionalStatus(CancellationToken cancellationToken)
        {
            var data = await _dbCon.AssetFunctionalStatus.Where(x => x.IsActive == true && x.IsRemoved == false)
               .Select(r => new SelectListItem()
               {
                   Text = r.StatusName,
                   Value = r.StatusID.ToString()
               }).ToListAsync(cancellationToken);
            return data;
        }
    }
}
