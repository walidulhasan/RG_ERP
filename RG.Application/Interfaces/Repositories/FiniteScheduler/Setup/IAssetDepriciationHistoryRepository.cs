using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetDepriciationHistories.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetDepriciationHistories.Queries.RequestResponseModel;
using RG.DBEntities.FiniteScheduler.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Setup
{
    public interface IAssetDepriciationHistoryRepository : IGenericRepository<AssetDepriciationHistory>
    {
        Task<RResult> AssetDepriciationHistoryCreate(AssetDepriciationHistory model, bool saveChange);
        Task<List<AssetDepriciationHistoryRM>> GetListAssetDepriciationHistory(int AssetID,CancellationToken cancellationToken);
    }
}
