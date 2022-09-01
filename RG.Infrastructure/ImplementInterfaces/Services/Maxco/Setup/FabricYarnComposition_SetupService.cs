using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.Maxco.Setup;
using RG.Application.Interfaces.Services.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Maxco.Setup
{
    public class FabricYarnComposition_SetupService : IFabricYarnComposition_SetupService
    {
        private readonly IFabricYarnComposition_SetupRepository _fabricYarnComposition_SetupRepository;

        public FabricYarnComposition_SetupService(IFabricYarnComposition_SetupRepository fabricYarnComposition_SetupRepository)
        {
            _fabricYarnComposition_SetupRepository = fabricYarnComposition_SetupRepository;
        }
        public async Task<List<SelectListItem>> DDLFabricYarnComposition(CancellationToken cancellationToken)
        {
            return await _fabricYarnComposition_SetupRepository.DDLFabricYarnComposition(cancellationToken);
        }
    }
}
