using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.Maxco.Setup;
using RG.DBEntities.Maxco.Setup;
using RG.Infrastructure.Persistence.MaxcoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Maxco.Setup
{
    public class FabricYarnComposition_SetupRepository : GenericRepository<FabricYarnComposition_Setup>, IFabricYarnComposition_SetupRepository
    {
        private readonly MaxcoDBContext _dbCon;
        public FabricYarnComposition_SetupRepository(MaxcoDBContext maxcoDBContext) : base(maxcoDBContext)
        {
            _dbCon = maxcoDBContext;
        }
        public async Task<List<SelectListItem>> DDLFabricYarnComposition(CancellationToken cancellationToken)
        {
            var data = await _dbCon.FabricYarnComposition_Setup
                 .Select(x => new SelectListItem
                 {
                     Text = x.Description.Trim(),
                     Value=x.ID.ToString()
                 }).ToListAsync(cancellationToken);
            return data;
        }
    }
}
