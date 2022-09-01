using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetDepriciationHistories.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetDepriciationHistories.Queries.RequestResponseModel;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.FiniteScheduler.Setup
{
    public interface IAssetDepriciationHistoryService
    {
        Task<RResult> AssetDepriciationHistoryCreate(AssetDepriciationHistory model, bool saveChange);
        Task<List<AssetDepriciationHistoryRM>> GetListAssetDepriciationHistory(int AssetID, CancellationToken cancellationToken);
        Task<RResult> assetDepriciationHistoryRemove(int id, bool saveChange);
        Task<RResult> AssetDepriciationHistoryUpdate(AssetDepriciationHistoryDTmodel modelDTM,bool saveChange);
    }
}
