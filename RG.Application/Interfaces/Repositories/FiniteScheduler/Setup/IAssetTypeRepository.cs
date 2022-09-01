using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetSubTypes.Query.RequestResponseModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetTypes.Query.RequestResponseModel;
using RG.DBEntities.FiniteScheduler.Setup;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Setup
{
    public interface IAssetTypeRepository : IGenericRepository<AssetType>
    {
        Task<RResult> Create(AssetType entity, CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLAssetTypeName(CancellationToken cancellationToken);
        IQueryable<AssetTypeRM> GetAllAssetType();
        
    }
}
