using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetDepriciationHistories.Commands.Update
{
    public class AssetDepriciationHistoryRemoveCommand:IRequest<RResult>
    {
        public int ID { get; set; }
    }
    public class AssetDepriciationHistoryRemoveCommandHandler : IRequestHandler<AssetDepriciationHistoryRemoveCommand, RResult>
    {
        private readonly IAssetDepriciationHistoryService _assetDepriciationHistoryService;

        public AssetDepriciationHistoryRemoveCommandHandler(IAssetDepriciationHistoryService assetDepriciationHistoryService)
        {
            _assetDepriciationHistoryService = assetDepriciationHistoryService;
        }
        public async Task<RResult> Handle(AssetDepriciationHistoryRemoveCommand request, CancellationToken cancellationToken)
        {
            return await _assetDepriciationHistoryService.assetDepriciationHistoryRemove(request.ID,true);
        }
    }
}
