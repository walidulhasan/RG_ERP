using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.FiniteScheduler.Setup
{
    public class AssetAssignedTypeService : IAssetAssignedTypeService
    {
        private readonly IAssetAssignedTypeRepository _assetAssignedTypeRepository;

        public AssetAssignedTypeService(IAssetAssignedTypeRepository assetAssignedTypeRepository)
        {
            _assetAssignedTypeRepository = assetAssignedTypeRepository;
        }
        public async Task<List<SelectListItem>> DDLAssetAssignedType(CancellationToken cancellationToken)
        {
            return await _assetAssignedTypeRepository.DDLAssetAssignedType(cancellationToken);
        }
    }
}
