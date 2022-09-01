using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetDepriciationHistories.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetDepriciationHistories.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.FiniteScheduler.Setup
{
    public class AssetDepriciationHistoryService : IAssetDepriciationHistoryService
    {
        private readonly IAssetDepriciationHistoryRepository _assetDepriciationHistoryRepository;

        public AssetDepriciationHistoryService(IAssetDepriciationHistoryRepository assetDepriciationHistoryRepository)
        {
            _assetDepriciationHistoryRepository = assetDepriciationHistoryRepository;
        }
        public async Task<RResult> AssetDepriciationHistoryCreate(AssetDepriciationHistory model, bool saveChange)
        {
            return await _assetDepriciationHistoryRepository.AssetDepriciationHistoryCreate(model, saveChange);
        }

        public async Task<List<AssetDepriciationHistoryRM>> GetListAssetDepriciationHistory(int AssetID, CancellationToken cancellationToken)
        {
            return await _assetDepriciationHistoryRepository.GetListAssetDepriciationHistory(AssetID,cancellationToken);
        }

        public async Task<RResult> assetDepriciationHistoryRemove(int id, bool saveChange)
        {
            RResult result = new();
            if (id > 0)
            {
                var entity = await _assetDepriciationHistoryRepository.GetByIdAsync(id);
                entity.IsRemoved = true;
                await _assetDepriciationHistoryRepository.UpdateAsync(entity, entity.ID, saveChange);
                result.result = 1;
                result.message = "Asset Depriciation History  Successfully Remove.";
            }
            else
            {
                result.result = 0;
                result.message = "Remove failed";
            }
            return result;
        }

        public async Task<RResult> AssetDepriciationHistoryUpdate(AssetDepriciationHistoryDTmodel modelDTM, bool saveChange)
        {
            RResult rResult = new();
            if (modelDTM != null)
            {
                var dbModel = await _assetDepriciationHistoryRepository.GetByIdAsync(modelDTM.ID);
                dbModel.DateTo = modelDTM.DateTo;
                dbModel.DateFrom = modelDTM.DateFrom;
                dbModel.Rate = modelDTM.Rate;
                if (modelDTM.ID > 0)
                {
                    await _assetDepriciationHistoryRepository.UpdateAsync(dbModel, saveChange);
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
