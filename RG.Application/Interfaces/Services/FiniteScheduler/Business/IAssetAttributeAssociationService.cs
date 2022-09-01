using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Business.AssetAttributeAssociation.Queries.RequestResponseModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetAttributeAssociations.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetAttributeAssociations.Queries.RequestResponseModel;
using RG.Application.Contracts.FiniteScheduler.Setups.SubTypeAttributeAssociations.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.SubTypeAttributeAssociations.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.FiniteScheduler.Business
{
    public interface IAssetAttributeAssociationService
    {
        Task<List<AssetSubTypeWiseAttributesRM>> GetAssetSubTypeWiseAttributes(int assetSubTypeID, CancellationToken cancellationToken);
        Task<List<SubTypeAttributeAssociationRM>> GetAssetSubTypeWiseAttribute(int ID, CancellationToken cancellationToken);
        Task<RResult> AssetAttributeAssociationCheckListSave(List<AssetAttributeAssociationDTM> model, bool saveChanges);
        Task<RResult> AssetAttributeAssociationCheckListRemove(List<AssetAttributeAssociationDTM> ListModel, CancellationToken cancellationToken);
        Task<RResult> AssetAttributeAssociationUpdate(AssetAttributeAssociationDTM model, CancellationToken cancellationToken);
        Task<List<FilterableAttributesRM>> AssetSubTypeWiseFilterableAttributes(int assetSubTypeID, CancellationToken cancellationToken);
       
    }
}
