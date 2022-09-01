using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetLocations.Commands.Update;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetLocations.Commands.Create
{
    public class AssetLocationCreateCommand : IRequest<RResult>
    {
        public AssetLocation dbmodel { get; set; }
    }
    public class AssetLocationCreateCommandHandler : IRequestHandler<AssetLocationCreateCommand, RResult>
    {
        private readonly IAssetLocationService _assetLocationService;

        public AssetLocationCreateCommandHandler(IAssetLocationService assetLocationService)
        {
            _assetLocationService = assetLocationService;
        }
        public async Task<RResult> Handle(AssetLocationCreateCommand request, CancellationToken cancellationToken)
        {
            return await _assetLocationService.AssetLoactionAssing(request.dbmodel, true);
        }
    }
}
