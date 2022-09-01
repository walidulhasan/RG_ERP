using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetSubTypes.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetSubTypes.Commands.Create
{
    public class AssetSubTypeCreateCommand : IRequest<RResult>
    {
        public AssetSubTypeDTM AssetSubType { get; set; }
    }
    public class AssetSubTypeCreateCommandHandler : IRequestHandler<AssetSubTypeCreateCommand, RResult>
    {
        private readonly IAssetSubTypeService _assetSubTypeService;

        public AssetSubTypeCreateCommandHandler(IAssetSubTypeService assetSubTypeService)
        {
            _assetSubTypeService = assetSubTypeService;
        }
        public async Task<RResult> Handle(AssetSubTypeCreateCommand request, CancellationToken cancellationToken)
        {
            return await _assetSubTypeService.Create(request.AssetSubType, cancellationToken);
        }
    }

}
