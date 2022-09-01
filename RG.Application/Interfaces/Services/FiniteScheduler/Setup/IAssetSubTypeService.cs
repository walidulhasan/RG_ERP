using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetSubTypes.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetSubTypes.Query.RequestResponseModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.FiniteScheduler.Setup
{
    public interface IAssetSubTypeService
    {
        Task<RResult> Create(AssetSubTypeDTM model, CancellationToken cancellationToken);
        IQueryable<AssetSubTypeRM> GetAllAssetSubType();
        Task<List<SelectListItem>> DDLAssetTypeWiseAssetSubType(int AssetTypeID, string predict, CancellationToken cancellationToken);
        Task<RResult> Update(AssetSubTypeDTM model, bool saveChange);
        Task<RResult> Remove(int AssetSubTypeID, bool saveChange);
    }
}
