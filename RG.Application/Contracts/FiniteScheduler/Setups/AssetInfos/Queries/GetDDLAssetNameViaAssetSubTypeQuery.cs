using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetInfos.Queries
{
    public class GetDDLAssetNameViaAssetSubTypeQuery:IRequest<List<SelectListItem>>
    {
        public int AssetSubTypeID { get; set; }

    }
    public class GetDDLAssetNameViaAssetSubTypeQueryHandler : IRequestHandler<GetDDLAssetNameViaAssetSubTypeQuery, List<SelectListItem>>
    {
        private readonly IAssetInfoService _assetInfoService;

        public GetDDLAssetNameViaAssetSubTypeQueryHandler(IAssetInfoService assetInfoService)
        {
            _assetInfoService = assetInfoService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLAssetNameViaAssetSubTypeQuery request, CancellationToken cancellationToken)
        {
            return await _assetInfoService.DDLAssetNameViaAssetSubType(request.AssetSubTypeID,cancellationToken);
        }
    }
}
