using RG.Application.Interfaces.Repositories.FiniteScheduler.Business;
using RG.Application.Interfaces.Services.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.FiniteScheduler.Business
{
    public class AssetAttributeAssociationValueService : IAssetAttributeAssociationValueService
    {
        private readonly IAssetAttributeAssociationValueRepository _assetAttributeAssociationValueRepository;

        public AssetAttributeAssociationValueService(IAssetAttributeAssociationValueRepository assetAttributeAssociationValueRepository)
        {
            _assetAttributeAssociationValueRepository = assetAttributeAssociationValueRepository;
        }
        public async Task<List<string>> AttributeValueAutoComplete(int assetSubTypeID, int attributeID,string predict, CancellationToken cancellationToken)
        {
            return await _assetAttributeAssociationValueRepository.AttributeValueAutoComplete(assetSubTypeID, attributeID,predict, cancellationToken);
        }
    }
}
