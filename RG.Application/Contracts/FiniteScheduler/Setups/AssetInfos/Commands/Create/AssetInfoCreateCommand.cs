using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetInfos.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using RG.Application.ViewModel.FiniteScheduler.Setup.AssetInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetInfos.Commands.Create
{
    public class AssetInfoCreateCommand:IRequest<RResult>
    {
        public AssetInfoDTM AssetInfoPC { get; set; }
    }
    public class AssetInfoCreateCommandHandler : IRequestHandler<AssetInfoCreateCommand, RResult>
    {
        private readonly IAssetInfoService _assetInfoService;

        public AssetInfoCreateCommandHandler(IAssetInfoService assetInfoService)
        {
            _assetInfoService = assetInfoService;
        }
        public async Task<RResult> Handle(AssetInfoCreateCommand request, CancellationToken cancellationToken)
        {
            return await _assetInfoService.Create(request.AssetInfoPC, true);           
        }
    }
}
