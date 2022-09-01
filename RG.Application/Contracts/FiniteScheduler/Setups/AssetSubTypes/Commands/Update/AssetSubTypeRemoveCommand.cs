using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetSubTypes.Commands.Update
{
    public class AssetSubTypeRemoveCommand:IRequest<RResult>
    {
        public int AssetSubTypeID { get; set; }
    }
    public class AssetSubTypeRemoveCommandHandler : IRequestHandler<AssetSubTypeRemoveCommand, RResult>
    {
        private readonly IAssetSubTypeService _assetSubTypeService;

        public AssetSubTypeRemoveCommandHandler(IAssetSubTypeService assetSubTypeService)
        {
            _assetSubTypeService = assetSubTypeService;
        }
        public async Task<RResult> Handle(AssetSubTypeRemoveCommand request, CancellationToken cancellationToken)
        {
            return await _assetSubTypeService.Remove(request.AssetSubTypeID,true);
        }
    }
}
