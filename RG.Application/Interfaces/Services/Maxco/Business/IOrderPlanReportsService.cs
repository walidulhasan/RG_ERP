using RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Maxco.Business
{
    public interface IOrderPlanReportsService
    {
        Task<List<GarmentAssortmentAndFabricsInfoRM>> GetGarmentAssortmentAndFabricsInfo(DateTime DateFrom, DateTime DateTo, int BuyerID, int OrderID);
        Task<List<GarmentAssortmentAndFabricsInfoRM>> GetPlannedOrderStatusReport(DateTime DateFrom, DateTime DateTo, int BuyerID, int OrderID = 0);

        //Task<WeeklySummaryVM> GetBuyerWiseFabricSummary(DateTime DateFrom, DateTime DateTo, int BuyerID, int OrderID);
        Task<List<GarmentAssortmentAndFabricsInfoRM>> GetBuyerWiseFabricSummaryReport(DateTime DateFrom, DateTime DateTo, int BuyerID, int OrderID);
        Task<List<GarmentAssortmentAndFabricsInfoRM>> GetFabricTypeWiseOrderStatusReport(DateTime DateFrom, DateTime DateTo, int BuyerID, int OrderID);
        Task<List<GarmentAssortmentAndFabricsInfoRM>> GetBuyerWiseStatusReport(DateTime DateFrom, DateTime DateTo, int BuyerID, int OrderID);
        Task<List<GarmentAssortmentAndFabricsInfoRM>> GetOrderWiseStatusReport(DateTime DateFrom, DateTime DateTo, int BuyerID, int OrderID);
        Task<List<GarmentAssortmentAndFabricsInfoRM>> GetWeekWiseStatusReport(DateTime DateFrom, DateTime DateTo, int BuyerID, int OrderID);
        Task<List<ArtWorkPlanRM>> GetPlanArtWorkReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID,CancellationToken cancellationToken);
        Task<List<DyeingUnitProductionFabricWeekRM>> GetDyeingProductionFinishFabricWeek(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken);
        Task Plan_GenerateReportData_Schedue();
        Task<List<GreigeFabricPlanRM>> GetPlanGreigeFabricReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken);
        Task<List<PlanNewOrderRM>> PlanNewOrderReport(DateTime DateFrom, DateTime DateTo, int BuyerID, int OrderID, CancellationToken cancellationToken);
        Task<List<DailyBatchRM>> GetDailyBatchReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken);
        Task<List<FinishFabricDeliveryRM>> GetDailyFinishFabricDeliveryReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken);
        Task<List<FabricFloorStatusRM>> GetFabricFloorStatusReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken);
        Task<List<DailyPrintProductionRM>> GetDailyPrintProductionSummeryReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken);
        Task<List<PlanUsedFabricCuttingSectionRM>> GetUsedFabricCuttingSection(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken);
        Task<List<ManagementStatusRM>> GetManagementStatusReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken);
    }
}
