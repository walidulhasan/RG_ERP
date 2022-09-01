using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetAssignedTypes.Queries
{
    public class GetDDLAssetAssignedTypeQuery : IRequest<List<SelectListItem>>
    {

    }
    public class GetDDLAssetAssignedTypeQueryHandler : IRequestHandler<GetDDLAssetAssignedTypeQuery, List<SelectListItem>>
    {
        private readonly IAssetAssignedTypeService _assetAssignedTypeService;

        public GetDDLAssetAssignedTypeQueryHandler(IAssetAssignedTypeService assetAssignedTypeService)
        {
            _assetAssignedTypeService = assetAssignedTypeService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLAssetAssignedTypeQuery request, CancellationToken cancellationToken)
        {
            return await _assetAssignedTypeService.DDLAssetAssignedType(cancellationToken);
        }
    }
}
