using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.Infrastructure.Persistence.MaxcoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Maxco.Setup
{
    public class FabricYarnCount_SetupRepository : GenericRepository<FabricYarnCount_Setup>, IFabricYarnCount_SetupRepository
    {
        private readonly MaxcoDBContext _dbCon;
        public FabricYarnCount_SetupRepository(MaxcoDBContext maxcoDBContext) : base(maxcoDBContext)
        {
            _dbCon = maxcoDBContext;
        }
        public async Task<List<SelectListItem>> DDLFabricYarnCount(bool descriptionInBothTextValue = false, CancellationToken cancellationToken=default)
        {
            var data = await _dbCon.FabricYarnCount_Setup
                .Select(x => new SelectListItem
                {
                    Text = x.Description.Trim(),
                    Value = descriptionInBothTextValue ? x.Description.Trim() : x.ID.ToString()
                }).ToListAsync(cancellationToken);
            return data;
        }
    }
}
