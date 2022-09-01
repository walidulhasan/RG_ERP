using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceItem_Setups.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceItem_Setups.Queries.RequestResponseModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.FiniteScheduler.Setup
{
    public interface IMT_MaintenanceItem_SetupService
    {
        IQueryable<MaintenanceItemRM> GetListOFMaintenanceItem(int ItemCategoryID);
        Task<List<SelectListItem>> DDLGetMT_MaintenanceItemList(int itemCategoryID, CancellationToken cancellationToken);
        Task<RResult> SaveMT_MaintenanceItem(MT_MaintenanceItem_SetupDTM model, bool saveChange);
        Task<RResult> UpdateMT_MaintenanceItem(MT_MaintenanceItem_SetupDTM model, bool saveChange);
        Task<RResult> RemoveMaintenanceItem(int itemID, bool saveChange);
    }
}
