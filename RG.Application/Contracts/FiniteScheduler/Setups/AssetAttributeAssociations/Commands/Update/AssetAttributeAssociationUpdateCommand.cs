using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetAttributeAssociations.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetAttributeAssociations.Commands.Update
{
    public class AssetAttributeAssociationUpdateCommand:IRequest<RResult>
    {
        public AssetAttributeAssociationDTM model { get; set; }
    }
    public class AssetAttributeAssociationUpdateCommandHandler : IRequestHandler<AssetAttributeAssociationUpdateCommand, RResult>
    {
        private readonly IAssetAttributeAssociationService _assetAttributeAssociationService;

        public AssetAttributeAssociationUpdateCommandHandler(IAssetAttributeAssociationService assetAttributeAssociationService)
        {
            _assetAttributeAssociationService = assetAttributeAssociationService;
        }
        public async Task<RResult> Handle(AssetAttributeAssociationUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _assetAttributeAssociationService.AssetAttributeAssociationUpdate(request.model,cancellationToken);
        }
    }
}
