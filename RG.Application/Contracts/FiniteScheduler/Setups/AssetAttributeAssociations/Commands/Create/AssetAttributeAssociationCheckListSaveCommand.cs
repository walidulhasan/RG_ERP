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

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetAttributeAssociations.Commands.Create
{
    public class AssetAttributeAssociationCheckListSaveCommand : IRequest<RResult>
    {
        public List<AssetAttributeAssociationDTM> assetAttributeAssociationDTM { get; set; }
    }
    public class AssetAttributeAssociationCheckListSaveCommandHandler : IRequestHandler<AssetAttributeAssociationCheckListSaveCommand, RResult>
    {
        private readonly IAssetAttributeAssociationService _assetAttributeAssociationService;

        public AssetAttributeAssociationCheckListSaveCommandHandler(IAssetAttributeAssociationService assetAttributeAssociationService)
        {
            _assetAttributeAssociationService = assetAttributeAssociationService;
        }
        public async Task<RResult> Handle(AssetAttributeAssociationCheckListSaveCommand request, CancellationToken cancellationToken)
        {
            return await _assetAttributeAssociationService.AssetAttributeAssociationCheckListSave(request.assetAttributeAssociationDTM, true);
        }
    }
}
