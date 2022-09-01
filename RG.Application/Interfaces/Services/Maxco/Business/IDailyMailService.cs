using RG.Application.Contracts.Maxco.Buisness.DailyMail.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Maxco.Business
{
    public interface IDailyMailService
    {
        Task KnittingProductionDefect(DateTime DtFrom);
        Task OverdueHnMInvoicesNotification();
        Task GetKnittingDailyProduction(DateTime ReportDate);
        Task SubContractGatePass(DateTime? stdate = null, DateTime? todate = null);
        Task DelayedVoucherPostingRBL(DateTime DateFrom);
        Task DelayedVoucherPostingCBL(DateTime DateFrom);
        Task PendingDyeingLotsCBL(DateTime DateFrom);
        Task PendingDyeingLotsRBL(DateTime DateFrom);
        Task UnsatisfiedReturnableGoods();


        //UnDone
        Task DailyKnittingShiftAndMachineWiseOverallPerformance(DateTime? DtFrom = null, DateTime? DtTo = null);
        Task FDBP_FDBCEntryNotification();//Maxco
        Task BTB_Cash_LC_OverdueMaturityNotification();//EMS
        Task DailyYarnStockReport(DateTime? DtFrom = null, DateTime? DtTo = null);//MaterialsManagement
        Task DailyKnittingShiftAndMachineWiseKnittingDefects(DateTime? DtFrom = null, DateTime? DtTo = null);//EMS
        Task Top_Cutting_Defects(DateTime? DtFrom = null, DateTime? DtTo = null);//FiniteScheduler
        Task LateDeliveries_HNM();//MaterialsManagement
        Task LateDeliveries_Others();//MaterialsManagement
        Task LateDeliveries_ConsumablesRBL();//MaterialsManagement
        Task LateDeliveries_ConsumablesCBL();//MaterialsManagement
    }
}
