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
    public class AssetAssignedTypeRepository : GenericRepository<AssetAssignedType>, IAssetAssignedTypeRepository
    {
        private readonly FiniteSchedulerDBContext _dbCon;

        public AssetAssignedTypeRepository(FiniteSchedulerDBContext context):base(context)
        {
            _dbCon = context;
        }

        public async Task<List<SelectListItem>> DDLAssetAssignedType(CancellationToken cancellationToken)
        {
            var query = _dbCon.AssetAssignedType.Where(x => x.IsActive == true && x.IsRemoved == false)
                                               .Select(x => new SelectListItem()
                                               {
                                                   Text=x.AssignedTypeName.ToString(),
                                                   Value=x.AssignedTypeNameID.ToString()
                                               });
            return await query.ToListAsync(cancellationToken);
        }
    }
}
