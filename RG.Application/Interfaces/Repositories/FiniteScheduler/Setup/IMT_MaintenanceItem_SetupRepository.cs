using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceItem_Setups.Queries.RequestResponseModel;
using RG.Application.ViewModel.FiniteScheduler.Setup.MaintenanceItem;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Setup
{
    public interface IMT_MaintenanceItem_SetupRepository:IGenericRepository<MT_MaintenanceItem_Setup>
    {
        IQueryable<MaintenanceItemRM> GetListOFMaintenanceItem(int ItemCategoryID);
        Task<List<SelectListItem>> DDLGetMT_MaintenanceItemList(int itemCategoryID, CancellationToken cancellationToken);
        Task<RResult> SaveMT_MaintenanceItem(MT_MaintenanceItem_Setup model, bool saveChange);
        Task<RResult> UpdateMT_MaintenanceItem(MT_MaintenanceItem_Setup model, bool saveChange);
        Task<RResult> CheckDuplicateMaintenanceItem(string itemName,int itemID=0);
    }
}
