using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceItem_Setups.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.DBEntities.FiniteScheduler.Setup;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Setup
{
    public class MT_MaintenanceItem_SetupRepository : GenericRepository<MT_MaintenanceItem_Setup>, IMT_MaintenanceItem_SetupRepository
    {
        private FiniteSchedulerDBContext dbCon;
        public MT_MaintenanceItem_SetupRepository(FiniteSchedulerDBContext context)
            : base(context)
        {
            dbCon = context;
        }

        public async Task<RResult> CheckDuplicateMaintenanceItem(string itemName, int itemID = 0)
        {
            var rResult = new RResult();
            var data = await dbCon.MT_MaintenanceItem_Setup.Where(x => x.IsActive == true && x.IsRemoved == false && x.ItemName == itemName && x.ID != itemID).FirstOrDefaultAsync();
            if (data == null)
                rResult.isDuplicate = false;
            else
                rResult.isDuplicate = true;
            return rResult;
        }

        public async Task<List<SelectListItem>> DDLGetMT_MaintenanceItemList(int itemCategoryID, CancellationToken cancellationToken)
        {
            var rtnList = await dbCon.MT_MaintenanceItem_Setup.Where(w => w.IsActive == true && w.IsRemoved == false && w.ItemCategoryID == itemCategoryID)
                .Select(s => new SelectListItem()
                {
                    Text = s.ItemName,
                    Value = s.ID.ToString()
                }).ToListAsync();
            return rtnList;
        }

        public IQueryable<MaintenanceItemRM> GetListOFMaintenanceItem(int ItemCategoryID)
        {
            var rtnList = from itemCat in dbCon.MT_MachineMaintenanceCategory_Setup
                          join item in dbCon.MT_MaintenanceItem_Setup on itemCat.ID equals item.ItemCategoryID
                          where item.IsActive == true && item.IsRemoved == false && (ItemCategoryID==0 || item.ItemCategoryID==ItemCategoryID)
                          select new MaintenanceItemRM()
                          {
                              ID = item.ID,
                              ItemCategoryID = item.ItemCategoryID,
                              ItemName = item.ItemName,
                              ItemCategoryName = itemCat.CategoryName
                          };
            return rtnList;
        }

        public async Task<RResult> SaveMT_MaintenanceItem(MT_MaintenanceItem_Setup model, bool saveChange)
        {
            var rResult = new RResult();
            try
            {
                await InsertAsync(model, saveChange);
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return rResult;
        }

        public async Task<RResult> UpdateMT_MaintenanceItem(MT_MaintenanceItem_Setup model, bool saveChange)
        {
            var rResult = new RResult();
            try
            {
                await UpdateAsync(model, saveChange);
                rResult.result = 1;
                rResult.message = ReturnMessage.UpdateMessage;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return rResult;
        }
    }
}
