using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetTypes.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetTypes.Commands.Update
{
    public class AssetTypesUpdateCommand:IRequest<RResult>
    {
        public AssetTypeDTM assetTypeDTM { get; set; }
    }
    public class AssetTypesUpdateCommandHandler : IRequestHandler<AssetTypesUpdateCommand, RResult>
    {
        private readonly IAssetTypeService _assetTypeService;

        public AssetTypesUpdateCommandHandler(IAssetTypeService assetTypeService)
        {
            _assetTypeService = assetTypeService;
        }
        public async Task<RResult> Handle(AssetTypesUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _assetTypeService.Update(request.assetTypeDTM,true);
        }
    }
}
