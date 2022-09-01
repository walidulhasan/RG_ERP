using MediatR;
using RG.Application.Contracts.FiniteScheduler.Setups.SubTypeAttributeAssociations.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.SubTypeAttributeAssociations.Queries
{
    public class GetAssetSubTypeWiseAttributeQuery:IRequest<List<SubTypeAttributeAssociationRM>>
    {
        public int id { get; set; }
    }
    public class GetAssetSubTypeWiseAttributeQueryHandler : IRequestHandler<GetAssetSubTypeWiseAttributeQuery, List<SubTypeAttributeAssociationRM>>
    {
        private readonly IAssetAttributeAssociationService _assetAttributeAssociationService;

        public GetAssetSubTypeWiseAttributeQueryHandler(IAssetAttributeAssociationService assetAttributeAssociationService)
        {
            _assetAttributeAssociationService = assetAttributeAssociationService;
        }
        public async Task<List<SubTypeAttributeAssociationRM>> Handle(GetAssetSubTypeWiseAttributeQuery request, CancellationToken cancellationToken)
        {
            return await _assetAttributeAssociationService.GetAssetSubTypeWiseAttribute(request.id,cancellationToken);
        }
    }
}
