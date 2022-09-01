using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetSubTypes.Query.RequestResponseModel;
using RG.DBEntities.FiniteScheduler.Setup;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Setup
{
    public interface IAssetSubTypeRepository : IGenericRepository<AssetSubType>
    {
        Task<RResult> Create(AssetSubType assetSubType, CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLAssetTypeWiseAssetSubType(int AssetTypeID, string predict, CancellationToken cancellationToken);
        IQueryable<AssetSubTypeRM> GetAllAssetSubType();
    }
}
