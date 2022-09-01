using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Business.AssetAttributeAssociation.Queries.RequestResponseModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetAttributeAssociations.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetAttributeAssociations.Queries.RequestResponseModel;
using RG.Application.Contracts.FiniteScheduler.Setups.SubTypeAttributeAssociations.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.SubTypeAttributeAssociations.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Business;
using RG.Application.Interfaces.Services.FiniteScheduler.Business;
using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.FiniteScheduler.Business
{
    public class AssetAttributeAssociationService : IAssetAttributeAssociationService
    {
        private readonly IAssetAttributeAssociationRepository _assetAttributeAssociationRepository;
        private readonly IMapper _mapper;
        private readonly IAssetDivisionRepository _assetDivisionRepository;

        public AssetAttributeAssociationService(IAssetAttributeAssociationRepository assetAttributeAssociationRepository, IMapper mapper, IAssetDivisionRepository assetDivisionRepository)
        {
            _assetAttributeAssociationRepository = assetAttributeAssociationRepository;
            _mapper = mapper;
            _assetDivisionRepository = assetDivisionRepository;
        }

        public async Task<List<SubTypeAttributeAssociationRM>> GetAssetSubTypeWiseAttribute(int ID, CancellationToken cancellationToken)
        {
            return await _assetAttributeAssociationRepository.GetAssetSubTypeWiseAttribute(ID,cancellationToken);
        }

        public async Task<List<AssetSubTypeWiseAttributesRM>> GetAssetSubTypeWiseAttributes(int assetSubTypeID, CancellationToken cancellationToken)
        {
            return await _assetAttributeAssociationRepository.GetAssetSubTypeWiseAttributes(assetSubTypeID, cancellationToken);
        }

        public async Task<RResult> AssetAttributeAssociationCheckListSave(List<AssetAttributeAssociationDTM> model, bool saveChanges)
        {
            var entities = _mapper.Map<List<AssetAttributeAssociationDTM>,List<AssetAttributeAssociation>>(model);
            return await _assetAttributeAssociationRepository.AssetAttributeAssociationCheckListSave(entities, saveChanges);
        }

        public async Task<RResult> AssetAttributeAssociationCheckListRemove(List<AssetAttributeAssociationDTM> ListModel, CancellationToken cancellationToken)
        {
            return await _assetAttributeAssociationRepository.AssetAttributeAssociationCheckListRemove(ListModel,cancellationToken);
        }

        public async Task<RResult> AssetAttributeAssociationUpdate(AssetAttributeAssociationDTM model, CancellationToken cancellationToken)
        {
            RResult rResult = new();
            try
            {
                var entity = await _assetAttributeAssociationRepository.GetByIdAsync(model.AssociationID, cancellationToken);
                entity.PrioritySerial = model.PrioritySerial;
                entity.IsFilterable = model.IsFilterable;
                entity.IsVisible = model.IsVisible;
                await _assetAttributeAssociationRepository.UpdateAsync(entity, true);
                rResult.result = 1;
                rResult.message = ReturnMessage.UpdateMessage;
            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = ReturnMessage.ErrorMessage;
            }
            return rResult;
        }

        public async Task<List<FilterableAttributesRM>> AssetSubTypeWiseFilterableAttributes(int assetSubTypeID, CancellationToken cancellationToken)
        {
            return await _assetAttributeAssociationRepository.AssetSubTypeWiseFilterableAttributes(assetSubTypeID, cancellationToken);
        }

       
    }
}
