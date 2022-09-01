using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.Maxco.Setup;
using RG.Application.Interfaces.Services.Maxco.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Maxco.Setup
{
    public class FabricYarnCount_SetupService : IFabricYarnCount_SetupService
    {
        private readonly IFabricYarnCount_SetupRepository _fabricYarnCount_SetupRepository;

        public FabricYarnCount_SetupService(IFabricYarnCount_SetupRepository fabricYarnCount_SetupRepository)
        {
            _fabricYarnCount_SetupRepository = fabricYarnCount_SetupRepository;
        }
        public async Task<List<SelectListItem>> DDLFabricYarnCount(bool descriptionInBothTextValue = false, CancellationToken cancellationToken = default)
        {
            return await _fabricYarnCount_SetupRepository.DDLFabricYarnCount(descriptionInBothTextValue, cancellationToken);
        }
    }
}
