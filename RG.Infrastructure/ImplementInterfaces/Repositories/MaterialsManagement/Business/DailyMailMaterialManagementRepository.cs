using RG.Application.Contracts.Maxco.Buisness.DailyMail.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.Infrastructure.Persistence.MaterialsManagementDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.MaterialsManagement.Business
{
    public class DailyMailMaterialManagementRepository : IDailyMailMaterialManagementRepository
    {
        private readonly MaterialsManagementDBContext _dbCon;

        public DailyMailMaterialManagementRepository(MaterialsManagementDBContext dbCon)
        {
            _dbCon = dbCon;
        }

        public async Task<List<DailyYarnStockReportRM>> DailyYarnStockReport(DateTime? DtFrom = null, DateTime? DtTo = null)
        {
            var itemList = new List<DailyYarnStockReportRM>();
            try
            {
                await _dbCon.LoadStoredProc("rpt.Mail_Daily_YARNStock_Transaction_Notification", commandTimeout: 500)
                    .WithSqlParam(nameof(DtFrom), DtFrom)
                    .WithSqlParam(nameof(DtTo), DtTo)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<DailyYarnStockReportRM>() as List<DailyYarnStockReportRM>;
                             });
                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<KnittingDailyNotificationRM>> GetKnittingDailyProduction(DateTime ReportDate)
        {
            var itemList = new List<KnittingDailyNotificationRM>();
            try
            {
                await _dbCon.LoadStoredProc("rpt.Mail_Knitting_Daily_Notification_backdate", commandTimeout: 500)
                             .WithSqlParam("ReportDate", ReportDate)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<KnittingDailyNotificationRM>() as List<KnittingDailyNotificationRM>;
                             });
                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<LateDeliveries_ConsumablesRM>> LateDeliveries_ConsumablesCBL()
        {
            var itemList = new List<LateDeliveries_ConsumablesRM>();
            try
            {
                await _dbCon.LoadStoredProc("rpt.Mail_LateDeliveries_Consumables_Comptex", commandTimeout: 500)

                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<LateDeliveries_ConsumablesRM>() as List<LateDeliveries_ConsumablesRM>;
                             });
                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<LateDeliveries_ConsumablesRM>> LateDeliveries_ConsumablesRBL()
        {
            var itemList = new List<LateDeliveries_ConsumablesRM>();
            try
            {
                await _dbCon.LoadStoredProc("rpt.Mail_LateDeliveries_Consumables_Robintex", commandTimeout: 500)

                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<LateDeliveries_ConsumablesRM>() as List<LateDeliveries_ConsumablesRM>;
                             });
                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<LateDeliveriesRM>> LateDeliveries_HNM()
        {
            var itemList = new List<LateDeliveriesRM>();
            try
            {
                await _dbCon.LoadStoredProc("rpt.Mail_LateDeliveries_HNM", commandTimeout: 500)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<LateDeliveriesRM>() as List<LateDeliveriesRM>;
                             });
                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<LateDeliveriesRM>> LateDeliveries_Others()
        {
            var itemList = new List<LateDeliveriesRM>();
            try
            {
                await _dbCon.LoadStoredProc("rpt.Mail_LateDeliveries_Others", commandTimeout: 500)

                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<LateDeliveriesRM>() as List<LateDeliveriesRM>;
                             });
                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<PendingDyeingLotsRM>> PendingDyeingLotsCBL(DateTime DateFrom)
        {
            var itemList = new List<PendingDyeingLotsRM>();
            try
            {
                await _dbCon.LoadStoredProc("rpt.Mail_Pending_Lot_Comptex", commandTimeout: 500)
                       .WithSqlParam("DateFrom", DateFrom)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<PendingDyeingLotsRM>() as List<PendingDyeingLotsRM>;
                             });
                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<List<PendingDyeingLotsRM>> PendingDyeingLotsRBL(DateTime DateFrom)
        {
            var itemList = new List<PendingDyeingLotsRM>();
            try
            {
                await _dbCon.LoadStoredProc("rpt.Mail_Pending_Lot_Robintex", commandTimeout: 500)
                             .WithSqlParam("DateFrom", DateFrom)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<PendingDyeingLotsRM>() as List<PendingDyeingLotsRM>;
                             });
                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<UnsatisfiedReturnableGoodsRM>> UnsatisfiedReturnableGoods()
        {
            var itemList = new List<UnsatisfiedReturnableGoodsRM>();
            try
            {
                await _dbCon.LoadStoredProc("rpt.Mail_UnsatisfiedGateItems_Notification", commandTimeout: 500)

                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<UnsatisfiedReturnableGoodsRM>() as List<UnsatisfiedReturnableGoodsRM>;
                             });
                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
