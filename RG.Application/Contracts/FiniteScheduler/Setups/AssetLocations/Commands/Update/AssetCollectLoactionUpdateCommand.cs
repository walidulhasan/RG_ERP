using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetLocations.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetLocations.Commands.Update
{
    public class AssetCollectLoactionUpdateCommand:IRequest<RResult>
    {
        public AssetLocationDTModel DTModel { get; set; }
    }
    public class AssetCollectLoactionUpdateCommandHandler : IRequestHandler<AssetCollectLoactionUpdateCommand, RResult>
    {
        private readonly IAssetLocationService _assetLocationService;

        public AssetCollectLoactionUpdateCommandHandler(IAssetLocationService assetLocationService)
        {
            _assetLocationService = assetLocationService;
        }
        public async Task<RResult> Handle(AssetCollectLoactionUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _assetLocationService.AssetCollectLoactionUpdate(request.DTModel,true);
        }
    }
}
