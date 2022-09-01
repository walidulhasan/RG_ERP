using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetCapacityUnit.Queries
{
    public class GetDDLAssetCapacityUnitQuery : IRequest<List<SelectListItem>>
    {
    }
    public class GetDDLAssetCapacityUnitQueryHandler : IRequestHandler<GetDDLAssetCapacityUnitQuery, List<SelectListItem>>
    {
        private readonly IAssetCapacityUnitService _assetCapacityUnitService;

        public GetDDLAssetCapacityUnitQueryHandler(IAssetCapacityUnitService assetCapacityUnitService)
        {
            _assetCapacityUnitService = assetCapacityUnitService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLAssetCapacityUnitQuery request, CancellationToken cancellationToken)
        {
            return await _assetCapacityUnitService.DDLAssetCapacityUnit(cancellationToken);
        }
    }
}
