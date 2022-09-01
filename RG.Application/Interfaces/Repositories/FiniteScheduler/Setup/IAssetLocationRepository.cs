using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetLocations.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetLocations.Queries.RequestResponseModel;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Setup
{
    public interface IAssetLocationRepository:IGenericRepository<AssetLocation>
    {
        Task<RResult> AssetLoactionAssing(AssetLocation model, bool saveChange);
        Task<AssetLocationRM> GetAssetLoactionByID(int ID, CancellationToken cancellationToken);
    }
}
