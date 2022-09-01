using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.FiniteScheduler.Setup
{
    public class AssetFunctionalStatusService : IAssetFunctionalStatusService
    {
        private readonly IAssetFunctionalStatusRepository _assetFunctionalStatusRepository;

        public AssetFunctionalStatusService(IAssetFunctionalStatusRepository assetFunctionalStatusRepository)
        {
            _assetFunctionalStatusRepository = assetFunctionalStatusRepository;
        }
        public async Task<List<SelectListItem>> DDLAssetFunctionalStatus(CancellationToken cancellationToken)
        {
            return await _assetFunctionalStatusRepository.DDLAssetFunctionalStatus(cancellationToken);
        }
    }
}
