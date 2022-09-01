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
    public class AssetAttributeAssociationCheckListRemoveCommand:IRequest<RResult>
    {
        public List<AssetAttributeAssociationDTM> modelList { get; set; }
    }
    public class AssetAttributeAssociationCheckListRemoveCommandHandler : IRequestHandler<AssetAttributeAssociationCheckListRemoveCommand, RResult>
    {
        private readonly IAssetAttributeAssociationService _assetAttributeAssociationService;

        public AssetAttributeAssociationCheckListRemoveCommandHandler(IAssetAttributeAssociationService assetAttributeAssociationService)
        {
            _assetAttributeAssociationService = assetAttributeAssociationService;
        }
        public async Task<RResult> Handle(AssetAttributeAssociationCheckListRemoveCommand request, CancellationToken cancellationToken)
        {
            return await _assetAttributeAssociationService.AssetAttributeAssociationCheckListRemove(request.modelList,cancellationToken);
        }
    }
}
