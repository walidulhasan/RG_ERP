using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetTypes.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetTypes.Commands.Create
{
    public class AssetTypeCreateCommand : IRequest<RResult>
    {
        public AssetTypeDTM AssetType { get; set; }
    }
    public class AssetTypeCreateCommandHandler : IRequestHandler<AssetTypeCreateCommand, RResult>
    {
        private readonly IAssetTypeService _assetTypeService;

        public AssetTypeCreateCommandHandler(IAssetTypeService assetTypeService)
        {
            _assetTypeService = assetTypeService;
        }
        public async Task<RResult> Handle(AssetTypeCreateCommand request, CancellationToken cancellationToken)
        {
            return await _assetTypeService.Create(request.AssetType, cancellationToken);
        }
    }
}
