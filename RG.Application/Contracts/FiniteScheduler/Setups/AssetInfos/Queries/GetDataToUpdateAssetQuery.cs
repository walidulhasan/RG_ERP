using MediatR;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetInfos.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using RG.Application.ViewModel.FiniteScheduler.Setup.AssetInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetInfos.Queries
{
    public class GetDataToUpdateAssetQuery:IRequest<AssetInfoVM>
    {
        public int Id { get; set; }
    }
    public class GetDataToUpdateAssetQueryHandler : IRequestHandler<GetDataToUpdateAssetQuery, AssetInfoVM>
    {
        private readonly IAssetInfoService _assetInfoService;

        public GetDataToUpdateAssetQueryHandler(IAssetInfoService assetInfoService)
        {
            _assetInfoService = assetInfoService;
        }
        public async Task<AssetInfoVM> Handle(GetDataToUpdateAssetQuery request, CancellationToken cancellationToken)
        {
            return await _assetInfoService.GetDataToUpdateAsset(request.Id,cancellationToken);
        }
    }
}
