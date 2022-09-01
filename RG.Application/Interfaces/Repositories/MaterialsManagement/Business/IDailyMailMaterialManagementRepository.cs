using RG.Application.Contracts.Maxco.Buisness.DailyMail.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.MaterialsManagement.Business
{
   public interface IDailyMailMaterialManagementRepository
    {
        Task<List<KnittingDailyNotificationRM>> GetKnittingDailyProduction(DateTime ReportDate);
        Task<List<PendingDyeingLotsRM>> PendingDyeingLotsCBL(DateTime DateFrom);
        Task<List<PendingDyeingLotsRM>> PendingDyeingLotsRBL(DateTime DateFrom);
        Task<List<UnsatisfiedReturnableGoodsRM>> UnsatisfiedReturnableGoods();
        Task<List<DailyYarnStockReportRM>> DailyYarnStockReport(DateTime? DtFrom = null, DateTime? DtTo = null);
        Task<List<LateDeliveriesRM>> LateDeliveries_HNM();
        Task<List<LateDeliveriesRM>> LateDeliveries_Others();
        Task<List<LateDeliveries_ConsumablesRM>> LateDeliveries_ConsumablesRBL();
        Task<List<LateDeliveries_ConsumablesRM>> LateDeliveries_ConsumablesCBL();
    }
}
