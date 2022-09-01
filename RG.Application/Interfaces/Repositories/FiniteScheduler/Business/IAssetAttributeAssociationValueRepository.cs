using RG.Application.ViewModel.FiniteScheduler.Setup.AssetInfo;
using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Business
{
    public interface IAssetAttributeAssociationValueRepository : IGenericRepository<AssetAttributeAssociationValue>
    {
        Task<List<AssetWiseAttributeValuesVM>> GetAssetWiseAttributeValues(int id, CancellationToken cancellationToken);
        Task<List<string>> AttributeValueAutoComplete(int assetSubTypeID, int attributeID,string predict, CancellationToken cancellationToken);
    }
}
