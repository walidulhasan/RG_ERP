using MediatR;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetIndexs.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetIndexs.Queries
{
    public class GetAllAssetAndRelationalInfoQuery:IRequest<List<GetAllAssetAndRelationalInfoRM>>
    {
        public GetAllAssetAndRelationalInfoQM queryModel { get; set; }
    }
    public class GetAllAssetAndRelationalInfoQueryHandler : IRequestHandler<GetAllAssetAndRelationalInfoQuery, List<GetAllAssetAndRelationalInfoRM>>
    {
        private readonly IAssetInfoService _assetInfoService;

        public GetAllAssetAndRelationalInfoQueryHandler(IAssetInfoService assetInfoService)
        {
            _assetInfoService = assetInfoService;
        }
        public async Task<List<GetAllAssetAndRelationalInfoRM>> Handle(GetAllAssetAndRelationalInfoQuery request, CancellationToken cancellationToken)
        {
            return await _assetInfoService.GetAllAssetAndRelationalInfo(request.queryModel,cancellationToken);
        }
    }
}
