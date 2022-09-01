using RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel;
using RG.Application.ViewModel.Maxco.Business.OrderPlanReports;
using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Maxco.Business
{
    public interface IOrderPlanReportsRepository
    {
        Task<PlannedOrderDetailInfoRM> GetGarmentAssortmentAndFabricsInfo(DateTime DateFrom, DateTime DateTo, int BuyerID, int OrderID);
        Task<PlannedAdditionalInfoRM> GetOrderAdditionalInfo(DateTime DateFrom, DateTime DateTo, int BuyerID, int OrderID);
        //Task<OrderStatusVM> GetPlannedOrderStatus(DateTime DateFrom, DateTime DateTo, int BuyerID, int OrderID);
        //Task<WeeklySummaryVM> GetBuyerWiseFabricSummary(DateTime DateFrom, DateTime DateTo, int BuyerID, int OrderID);

        Task<List<PlanArtWorkFabricConsumptionRM>> GetArtWorkPlanDaa(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID,CancellationToken cancellationToken);
        IQueryable<Plan_OrderGreigeQuantityReport> GetPlan_OrderGreigeQuantityReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID);
        IQueryable<Plan_OrderBatchAndFinishQuantityReport> GetPlan_OrderBatchAndFinishQuantityReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID);
        Task Plan_GenerateReportData_Schedue();
        Task<List<DyeingUnitProductionFabricWeekRM>> GetDyeingProductionFinishFabricWeek(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken);
        Task<List<GreigeFabricPlanRM>> GetPlanGreigeFabricReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken);
        Task<List<DailyBatchRM>> GetDailyBatchReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken);
        Task<List<FinishFabricDeliveryRM>> GetDailyFinishFabricDeliveryReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken);
        Task<List<FabricFloorStatusRM>> GetFabricFloorStatusReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken);
        Task<List<DailyPrintProductionRM>> GetDailyPrintProductionSummeryReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken);
        Task<List<PlanUsedFabricCuttingSectionRM>> GetUsedFabricCuttingSection(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken);
        Task<List<ManagementStatusRM>> GetManagementStatusReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken);
        
    }
}
