using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Maxco.Setup
{
    public interface IFabricYarnComposition_SetupService
    {
        Task<List<SelectListItem>> DDLFabricYarnComposition(CancellationToken cancellationToken);
    }
}
