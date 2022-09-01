using MediatR;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetDepriciationHistories.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetDepriciationHistories.Queries
{
    public class GetListAssetDepriciationHistoryQuery:IRequest<List<AssetDepriciationHistoryRM>>
    {
        public int assetID { get; set; }
    }
    public class GetListAssetDepriciationHistoryQueryHandler : IRequestHandler<GetListAssetDepriciationHistoryQuery, List<AssetDepriciationHistoryRM>>
    {
        private readonly IAssetDepriciationHistoryService _assetDepriciationHistoryService;

        public GetListAssetDepriciationHistoryQueryHandler(IAssetDepriciationHistoryService assetDepriciationHistoryService)
        {
            _assetDepriciationHistoryService = assetDepriciationHistoryService;
        }
        public async Task<List<AssetDepriciationHistoryRM>> Handle(GetListAssetDepriciationHistoryQuery request, CancellationToken cancellationToken)
        {
            return await _assetDepriciationHistoryService.GetListAssetDepriciationHistory(request.assetID, cancellationToken);
        }
    }
}
