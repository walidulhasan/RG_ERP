using MediatR;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetAttributeAssociations.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetAttributeAssociations.Queries
{
    public class AssetSubTypeWiseFilterableAttributesQuery:IRequest<List<FilterableAttributesRM>>
    {
        public int AssetSubTypeID { get; set; }
    }
    public class AssetSubTypeWiseFilterableAttributesQueryHandler : IRequestHandler<AssetSubTypeWiseFilterableAttributesQuery, List<FilterableAttributesRM>>
    {
        private readonly IAssetAttributeAssociationService _assetAttributeAssociationService;

        public AssetSubTypeWiseFilterableAttributesQueryHandler(IAssetAttributeAssociationService assetAttributeAssociationService)
        {
            _assetAttributeAssociationService = assetAttributeAssociationService;
        }
        public async Task<List<FilterableAttributesRM>> Handle(AssetSubTypeWiseFilterableAttributesQuery request, CancellationToken cancellationToken)
        {
            return await _assetAttributeAssociationService.AssetSubTypeWiseFilterableAttributes(request.AssetSubTypeID, cancellationToken);
        }
    }
}
