using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Business;
using RG.DBEntities.FiniteScheduler.Business;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Business
{
    public class AssetDivisionRepository:GenericRepository<AssetDivision>, IAssetDivisionRepository
    {
        private readonly FiniteSchedulerDBContext _dbcon;

        public AssetDivisionRepository(FiniteSchedulerDBContext dbcon):base(dbcon)
        {
            _dbcon = dbcon;
        }

        public async Task<List<SelectListItem>> EmbroCompanyWiseDDLDivision(int embroCompanyID, string Predict = null, CancellationToken cancellationToken = default)
        {
           var query = _dbcon.AssetDivision.Where(x => x.EmbroCompanyID == embroCompanyID)
                .Select(x => new SelectListItem
                {
                    Text = x.DivisionName,
                    Value = x.DivisionID.ToString()
                });
            if (Predict != null)
            {
                query = query.Where(x => x.Text.Contains(Predict));
            }
            return await query.ToListAsync(cancellationToken);

        }
    }
}
