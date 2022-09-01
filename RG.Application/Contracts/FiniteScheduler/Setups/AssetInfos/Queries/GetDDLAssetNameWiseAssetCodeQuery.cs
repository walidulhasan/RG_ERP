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
    public class GetDDLAssetNameWiseAssetCodeQuery:IRequest<List<SelectListItem>>
    {
        public string AssetName { get; set; }
    }
    public class GetDDLAssetNameWiseAssetCodeQueryHandler : IRequestHandler<GetDDLAssetNameWiseAssetCodeQuery, List<SelectListItem>>
    {
        private readonly IAssetInfoService _assetInfoService;

        public GetDDLAssetNameWiseAssetCodeQueryHandler(IAssetInfoService assetInfoService)
        {
            _assetInfoService = assetInfoService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLAssetNameWiseAssetCodeQuery request, CancellationToken cancellationToken)
        {
            return await _assetInfoService.DDLAssetNameWiseAssetCode(request.AssetName, cancellationToken);
        }
    }
}
