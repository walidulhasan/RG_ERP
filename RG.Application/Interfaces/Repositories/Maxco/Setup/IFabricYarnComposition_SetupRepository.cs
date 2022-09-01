using Microsoft.AspNetCore.Mvc.Rendering;
using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Maxco.Setup
{
    public interface IFabricYarnComposition_SetupRepository:IGenericRepository<FabricYarnComposition_Setup>
    {
        Task<List<SelectListItem>> DDLFabricYarnComposition(CancellationToken cancellationToken);
    }
}
