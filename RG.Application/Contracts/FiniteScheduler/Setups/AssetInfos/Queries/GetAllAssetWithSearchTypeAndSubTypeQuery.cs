using MediatR;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetInfos.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetInfos.Queries
{
    public class GetAllAssetWithSearchTypeAndSubTypeQuery:IRequest<List<AssetInfoRM>>
    {
        public int AssetTypeID { get; set; }
        public int AssetTypeSubID { get; set; }
    }
    public class GetAllAssetWithSearchTypeAndSubTypeQueryHandler : IRequestHandler<GetAllAssetWithSearchTypeAndSubTypeQuery, List<AssetInfoRM>>
    {
        private readonly IAssetInfoService _assetInfoService;

        public GetAllAssetWithSearchTypeAndSubTypeQueryHandler(IAssetInfoService assetInfoService)
        {
            _assetInfoService = assetInfoService;
        }
        public async Task<List<AssetInfoRM>> Handle(GetAllAssetWithSearchTypeAndSubTypeQuery request, CancellationToken cancellationToken)
        {
            return await _assetInfoService.GetAllAssetWithSearchTypeAndSubType(request.AssetTypeID,request.AssetTypeSubID,cancellationToken);
        }
    }
}
