using Microsoft.AspNetCore.Mvc.Rendering;
using RG.DBEntities.Maxco.FabricAndYarn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Maxco.Setup
{
    public interface IFabricYarnCount_SetupRepository:IGenericRepository<FabricYarnCount_Setup>
    {
        Task<List<SelectListItem>> DDLFabricYarnCount(bool descriptionInBothTextValue=false, CancellationToken cancellationToken=default);
    }
}
