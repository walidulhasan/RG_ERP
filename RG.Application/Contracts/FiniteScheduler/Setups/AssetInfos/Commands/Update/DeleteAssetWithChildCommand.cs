using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetInfos.Commands.Update
{
    public class DeleteAssetWithChildCommand : IRequest<RResult>
    {
        public int AssetID { get; set; }
    }
    public class AssetInfoRemoveCommandHander : IRequestHandler<DeleteAssetWithChildCommand, RResult>
    {
        private readonly IAssetInfoService _assetInfoService;

        public AssetInfoRemoveCommandHander(IAssetInfoService assetInfoService)
        {
            _assetInfoService = assetInfoService;
        }
        public async Task<RResult> Handle(DeleteAssetWithChildCommand request, CancellationToken cancellationToken)
        {
            return await _assetInfoService.DeleteAssetWithChild(request.AssetID);
        }
    }
}
