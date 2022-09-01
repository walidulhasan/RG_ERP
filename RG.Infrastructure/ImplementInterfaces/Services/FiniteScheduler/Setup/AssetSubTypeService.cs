using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetSubTypes.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetSubTypes.Query.RequestResponseModel;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using RG.DBEntities.FiniteScheduler.Setup;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.FiniteScheduler.Setup
{
    public class AssetSubTypeService : IAssetSubTypeService
    {
        private readonly IAssetSubTypeRepository _assetSubTypeRepository;
        private readonly IMapper _mapper;

        public AssetSubTypeService(IAssetSubTypeRepository assetSubTypeRepository, IMapper mapper)
        {
            _assetSubTypeRepository = assetSubTypeRepository;
            _mapper = mapper;
        }
        public async Task<RResult> Create(AssetSubTypeDTM model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<AssetSubTypeDTM, AssetSubType>(model);
            return await _assetSubTypeRepository.Create(entity, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLAssetTypeWiseAssetSubType(int AssetTypeID, string predict, CancellationToken cancellationToken)
        {
            return await _assetSubTypeRepository.DDLAssetTypeWiseAssetSubType(AssetTypeID, predict, cancellationToken);
        }

        public IQueryable<AssetSubTypeRM> GetAllAssetSubType()
        {
            return _assetSubTypeRepository.GetAllAssetSubType();
        }

        public async Task<RResult> Remove(int AssetSubTypeID, bool saveChange)
        {
            RResult rResult = new();
            if (AssetSubTypeID > 0)
            {
                var dbModel = await _assetSubTypeRepository.GetByIdAsync(AssetSubTypeID);
                dbModel.IsRemoved = true;
                await _assetSubTypeRepository.UpdateAsync(dbModel, saveChange);
                rResult.result = 1;
                rResult.message = ReturnMessage.DeleteMessage;
            }
            else
            {
                rResult.result = 0;
                rResult.message = ReturnMessage.ErrorMessage;
            }
            return rResult;
        }

        public async Task<RResult> Update(AssetSubTypeDTM model, bool saveChange)
        {
            RResult rResult = new();
            if (model != null)
            {
                var dbModel = await _assetSubTypeRepository.GetByIdAsync(model.AssetTypeID);
                dbModel.AssetTypeID = model.AssetTypeID;
                dbModel.Code = model.Code.ToUpper();
                dbModel.Description = model.Description;
                dbModel.SubTypeName = model.SubTypeName;
                if (model.AssetSubTypeID > 0)
                {
                    await _assetSubTypeRepository.UpdateAsync(dbModel, saveChange);
                    rResult.result = 1;
                    rResult.message = ReturnMessage.UpdateMessage;
                }
                else
                {
                    rResult.result = 0;
                    rResult.message = ReturnMessage.ErrorMessage;
                }

            }
            return rResult;
        }
    }
}
