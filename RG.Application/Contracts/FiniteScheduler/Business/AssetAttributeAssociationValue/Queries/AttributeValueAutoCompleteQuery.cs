using MediatR;
using RG.Application.Interfaces.Services.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Business.AssetAttributeAssociationValue.Queries
{
    public class AttributeValueAutoCompleteQuery:IRequest<List<string>>
    {
        public int AssetSubTypeID { get; set; }
        public int AttributeID { get; set; }
        public string Predict { get; set; }
    }
    public class AttributeValueAutoCompleteQueryHandler : IRequestHandler<AttributeValueAutoCompleteQuery, List<string>>
    {
        private readonly IAssetAttributeAssociationValueService _assetAttributeAssociationValueService;

        public AttributeValueAutoCompleteQueryHandler(IAssetAttributeAssociationValueService assetAttributeAssociationValueService)
        {
            _assetAttributeAssociationValueService = assetAttributeAssociationValueService;
        }
        public async Task<List<string>> Handle(AttributeValueAutoCompleteQuery request, CancellationToken cancellationToken)
        {
            return await _assetAttributeAssociationValueService.AttributeValueAutoComplete(request.AssetSubTypeID, request.AttributeID,request.Predict, cancellationToken);
        }
    }
}
