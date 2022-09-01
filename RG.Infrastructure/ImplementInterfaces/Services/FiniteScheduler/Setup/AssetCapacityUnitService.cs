using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.FiniteScheduler.Setup
{
    public class AssetCapacityUnitService : IAssetCapacityUnitService
    {
        private readonly IAssetCapacityUnitRepository _assetCapacityUnitRepository;

        public AssetCapacityUnitService(IAssetCapacityUnitRepository assetCapacityUnitRepository)
        {
            _assetCapacityUnitRepository = assetCapacityUnitRepository;
        }
        public async Task<List<SelectListItem>> DDLAssetCapacityUnit(CancellationToken cancellationToken)
        {
            return await _assetCapacityUnitRepository.DDLAssetCapacityUnit(cancellationToken);
        }
    }
}
