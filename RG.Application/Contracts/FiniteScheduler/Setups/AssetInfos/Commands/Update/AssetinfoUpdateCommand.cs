using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetInfos.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetInfos.Commands.Update
{
    public class AssetinfoUpdateCommand:IRequest<RResult>
    {
        public AssetInfoDTM assetInfoDTM { get; set; }
    }
    public class AssetinfoUpdateCommandHandler : IRequestHandler<AssetinfoUpdateCommand, RResult>
    {
        private readonly IAssetInfoService _assetInfoService;

        public AssetinfoUpdateCommandHandler(IAssetInfoService assetInfoService)
        {
            _assetInfoService = assetInfoService;
        }
        public async Task<RResult> Handle(AssetinfoUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _assetInfoService.AssetinfoUpdate(request.assetInfoDTM,true);
        }
    }
}
