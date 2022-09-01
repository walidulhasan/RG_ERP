using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetDepriciationHistories.Commands.Create
{
    public class AssetDepriciationHistorieCreateCommand:IRequest<RResult>
    {
        public AssetDepriciationHistory assetDepriciationHistory  { get; set; }
    }
    public class AssetDepriciationHistorieCreateCommandHandler : IRequestHandler<AssetDepriciationHistorieCreateCommand, RResult>
    {
        private readonly IAssetDepriciationHistoryService _assetDepriciationHistoryService;

        public AssetDepriciationHistorieCreateCommandHandler(IAssetDepriciationHistoryService assetDepriciationHistoryService)
        {
            _assetDepriciationHistoryService = assetDepriciationHistoryService;
        }
        public async Task<RResult> Handle(AssetDepriciationHistorieCreateCommand request, CancellationToken cancellationToken)
        {
            return await _assetDepriciationHistoryService.AssetDepriciationHistoryCreate(request.assetDepriciationHistory,true);
        }
    }
}
