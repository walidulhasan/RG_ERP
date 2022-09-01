using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetTypes.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetTypes.Query.RequestResponseModel;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.FiniteScheduler.Setup
{
    public class AssetTypeService : IAssetTypeService
    {
        private readonly IAssetTypeRepository _assetTypeRepository;
        private readonly IMapper _mapper;

        public AssetTypeService(IAssetTypeRepository assetTypeRepository,IMapper mapper)
        {
            _assetTypeRepository = assetTypeRepository;
            _mapper = mapper;
        }
        public async Task<RResult> Create(AssetTypeDTM model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<AssetTypeDTM, AssetType>(model);
            return await _assetTypeRepository.Create(entity, cancellationToken);
        }

        public IQueryable<AssetTypeRM> GetAllAssetType()
        {
            return _assetTypeRepository.GetAllAssetType();
        }

        public async Task<List<SelectListItem>> GetDDLAssetTypeName(CancellationToken cancellationToken)
        {
            return await _assetTypeRepository.DDLAssetTypeName(cancellationToken);
        }

        public async Task<RResult> Remove(int assetTypeID, bool saveChange)
        {
            RResult result = new RResult();
            var dbModel = await _assetTypeRepository.GetByIdAsync(assetTypeID);
            dbModel.IsRemoved = true;
            if (assetTypeID>0)
            {
                await _assetTypeRepository.UpdateAsync(dbModel, saveChange);
                result.result = 1;
                result.message = ReturnMessage.DeleteMessage;
            }
            else
            {
                result.result = 0;
                result.message = ReturnMessage.ErrorMessage;
            }
            
            return result;

        }

        public async Task<RResult> Update(AssetTypeDTM model, bool saveChange)
        {
            try
            {
                RResult result = new();
                var dbModel = await _assetTypeRepository.GetByIdAsync(model.AssetTypeID);
                dbModel.TypeName = model.TypeName;
                dbModel.Code = model.Code.ToUpper();
                dbModel.Description = model.Description;
                if (model.AssetTypeID>0)
                {
                    await _assetTypeRepository.UpdateAsync(dbModel, saveChange);
                    result.result = 1;
                    result.message = ReturnMessage.UpdateMessage;
                }
                else
                {
                    result.result = 0;
                    result.message = ReturnMessage.ErrorMessage;
                }
               
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
