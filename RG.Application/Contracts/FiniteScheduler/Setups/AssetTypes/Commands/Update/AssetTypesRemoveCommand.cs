using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetTypes.Commands.Update
{
    public class AssetTypesRemoveCommand:IRequest<RResult>
    {
        public int AssetTypeID { get; set; }
    }
    public class AssetTypesRemoveCommandHandler : IRequestHandler<AssetTypesRemoveCommand, RResult>
    {
        private readonly IAssetTypeService _assetTypeService;

        public AssetTypesRemoveCommandHandler(IAssetTypeService assetTypeService)
        {
            _assetTypeService = assetTypeService;
        }
        public async Task<RResult> Handle(AssetTypesRemoveCommand request, CancellationToken cancellationToken)
        {
            return await _assetTypeService.Remove(request.AssetTypeID,true);
        }
    }
}
