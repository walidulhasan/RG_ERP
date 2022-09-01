using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetLocations.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetLocations.Queries.RequestResponseModel;
using RG.DBEntities.FiniteScheduler.Setup;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.FiniteScheduler.Setup
{
    public  interface IAssetLocationService
    {
        Task<RResult> AssetLoactionAssing(AssetLocation model, bool saveChange);
        Task<AssetLocationRM> GetAssetLoactionByID(int ID, CancellationToken cancellationToken);
        Task<RResult> AssetCollectLoactionUpdate(AssetLocationDTModel DTmodel, bool saveChange);
    }
}
