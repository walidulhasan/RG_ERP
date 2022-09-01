using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetTypes.Query
{
    public class GetAssetTypeNameQuery:IRequest<List<SelectListItem>>
    {
    }
    public class GetAssetTypeNameQueryHandler : IRequestHandler<GetAssetTypeNameQuery, List<SelectListItem>>
    {
        private readonly IAssetTypeService _assetTypeService;

        public GetAssetTypeNameQueryHandler(IAssetTypeService assetTypeService)
        {
            _assetTypeService = assetTypeService;
        }
        public async Task<List<SelectListItem>> Handle(GetAssetTypeNameQuery request, CancellationToken cancellationToken)
        {
            return await _assetTypeService.GetDDLAssetTypeName(cancellationToken);
        }
    }
}
