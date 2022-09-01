using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetDepriciationHistories.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetDepriciationHistories.Commands.Update
{
    public class AssetDepriciationHistoryUpdateCommand:IRequest<RResult>
    {
        public AssetDepriciationHistoryDTmodel DTmodel { get; set; }
    }
    public class AssetDepriciationHistoryUpdateCommandHandler : IRequestHandler<AssetDepriciationHistoryUpdateCommand, RResult>
    {
        private readonly IAssetDepriciationHistoryService _assetDepriciationHistoryService;

        public AssetDepriciationHistoryUpdateCommandHandler(IAssetDepriciationHistoryService assetDepriciationHistoryService)
        {
            _assetDepriciationHistoryService = assetDepriciationHistoryService;
        }
        public async Task<RResult> Handle(AssetDepriciationHistoryUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _assetDepriciationHistoryService.AssetDepriciationHistoryUpdate(request.DTmodel,true);
        }
    }
}
