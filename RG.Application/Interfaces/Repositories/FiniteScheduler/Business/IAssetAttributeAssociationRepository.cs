using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Business.AssetAttributeAssociation.Queries.RequestResponseModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetAttributeAssociations.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetAttributeAssociations.Queries.RequestResponseModel;
using RG.Application.Contracts.FiniteScheduler.Setups.SubTypeAttributeAssociations.Queries.RequestResponseModel;
using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Business
{
    public interface IAssetAttributeAssociationRepository:IGenericRepository<AssetAttributeAssociation>
    {
        Task<List<AssetSubTypeWiseAttributesRM>> GetAssetSubTypeWiseAttributes(int AssetSubTypeID, CancellationToken cancellationToken);
        Task<List<SubTypeAttributeAssociationRM>> GetAssetSubTypeWiseAttribute(int ID, CancellationToken cancellationToken);
        Task<RResult> AssetAttributeAssociationCheckListSave(List<AssetAttributeAssociation>  entity, bool saveChanges);
        Task<RResult> AssetAttributeAssociationCheckListRemove(List<AssetAttributeAssociationDTM> ListModel,CancellationToken cancellationToken);
        Task<List<FilterableAttributesRM>> AssetSubTypeWiseFilterableAttributes(int assetSubTypeID, CancellationToken cancellationToken);
    }
}
