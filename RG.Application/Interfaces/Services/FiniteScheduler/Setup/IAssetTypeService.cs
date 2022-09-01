using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetTypes.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetTypes.Query.RequestResponseModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.FiniteScheduler.Setup
{
    public interface IAssetTypeService
    {
        Task<RResult> Create(AssetTypeDTM model, CancellationToken cancellationToken);
        Task<List<SelectListItem>> GetDDLAssetTypeName(CancellationToken cancellationToken);
        IQueryable<AssetTypeRM> GetAllAssetType();
        Task<RResult> Update(AssetTypeDTM model, bool saveChange);
        Task<RResult> Remove(int assetTypeID, bool saveChange);
    }
}
