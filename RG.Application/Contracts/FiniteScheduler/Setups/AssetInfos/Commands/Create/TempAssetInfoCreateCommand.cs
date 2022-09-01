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

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetInfos.Commands.Create
{
    public class TempAssetInfoCreateCommand : IRequest<RResult>
    {
        public AssetInfoDTM AssetInfoPC { get; set; }
    }
    public class TempAssetInfoCreateCommandHandler : IRequestHandler<TempAssetInfoCreateCommand, RResult>
    {
        private readonly IAssetInfoService _assetInfoService;

        public TempAssetInfoCreateCommandHandler(IAssetInfoService assetInfoService)
        {
            _assetInfoService = assetInfoService;
        }
        public async Task<RResult> Handle(TempAssetInfoCreateCommand request, CancellationToken cancellationToken)
        {           
            return await _assetInfoService.TempAssetCreate();
        }
    }
}