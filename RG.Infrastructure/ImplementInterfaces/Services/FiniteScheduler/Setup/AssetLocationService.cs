using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetLocations.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetLocations.Queries.RequestResponseModel;
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
    public class AssetLocationService : IAssetLocationService
    {
        private readonly IAssetLocationRepository _assetInfoRepository;

        public AssetLocationService(IAssetLocationRepository assetInfoRepository)
        {
            _assetInfoRepository = assetInfoRepository;
        }

        public async Task<RResult> AssetCollectLoactionUpdate(AssetLocationDTModel DTmodel, bool saveChange)
        {
            RResult rResult = new();
            if (DTmodel != null)
            {
                var dbModel = await _assetInfoRepository.GetByIdAsync(DTmodel.ID);
                dbModel.DateTo = DTmodel.DateTo;
                dbModel.IsReturned = true;
                if (DTmodel.ID > 0)
                {
                    await _assetInfoRepository.UpdateAsync(dbModel, saveChange);
                    rResult.result = 1;
                    rResult.message = "Asset Collection Successful";
                }
                else
                {
                    rResult.result = 0;
                    rResult.message = ReturnMessage.ErrorMessage;
                }

            }
            return rResult;
        }

        public async Task<RResult> AssetLoactionAssing(AssetLocation model, bool saveChange)
        {
            return await _assetInfoRepository.AssetLoactionAssing(model,true);
        }
        public async Task<AssetLocationRM> GetAssetLoactionByID(int ID, CancellationToken cancellationToken)
        {
            return await _assetInfoRepository.GetAssetLoactionByID(ID,cancellationToken);
        }
    }
}
