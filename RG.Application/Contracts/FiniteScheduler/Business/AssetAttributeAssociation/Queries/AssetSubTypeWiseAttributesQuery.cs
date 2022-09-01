using MediatR;
using RG.Application.Contracts.FiniteScheduler.Business.AssetAttributeAssociation.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Business.AssetAttributeAssociation.Queries
{
    public class AssetSubTypeWiseAttributesQuery : IRequest<List<AssetSubTypeWiseAttributesRM>>
    {
        public int AssetSubTypeID { get; set; }
    }
    public class AssetSubTypeWiseAttributesQueryHandler : IRequestHandler<AssetSubTypeWiseAttributesQuery, List<AssetSubTypeWiseAttributesRM>>
    {
        private readonly IAssetAttributeAssociationService _assetAttributeAssociationService;

        public AssetSubTypeWiseAttributesQueryHandler(IAssetAttributeAssociationService assetAttributeAssociationService)
        {
            _assetAttributeAssociationService = assetAttributeAssociationService;
        }
        public async Task<List<AssetSubTypeWiseAttributesRM>> Handle(AssetSubTypeWiseAttributesQuery request, CancellationToken cancellationToken)
        {
            return await _assetAttributeAssociationService.GetAssetSubTypeWiseAttributes(request.AssetSubTypeID, cancellationToken);
        }
    }
}
