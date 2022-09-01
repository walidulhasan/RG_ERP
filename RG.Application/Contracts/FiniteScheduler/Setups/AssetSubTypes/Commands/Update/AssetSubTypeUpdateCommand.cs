using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetSubTypes.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetSubTypes.Commands.Update
{
    public class AssetSubTypeUpdateCommand:IRequest<RResult>
    {
        public AssetSubTypeDTM assetSubTypeDTM { get; set; }
    }
    public class AssetSubTypeUpdateCommandHandler : IRequestHandler<AssetSubTypeUpdateCommand, RResult>
    {
        private readonly IAssetSubTypeService _assetSubTypeService;

        public AssetSubTypeUpdateCommandHandler(IAssetSubTypeService assetSubTypeService)
        {
            _assetSubTypeService = assetSubTypeService;
        }
        public async Task<RResult> Handle(AssetSubTypeUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _assetSubTypeService.Update(request.assetSubTypeDTM,true);
        }
    }
}
