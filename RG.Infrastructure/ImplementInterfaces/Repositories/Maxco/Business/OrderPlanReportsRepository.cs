using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Maxco.Business;
using RG.Application.ViewModel.Maxco.Business.OrderPlanReports;
using RG.DBEntities.Maxco.Business;
using RG.Infrastructure.Persistence.MaxcoDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Maxco.Business
{
    public class OrderPlanReportsRepository : IOrderPlanReportsRepository
    {
        private readonly MaxcoDBContext dbCon;
        private readonly ILogger<OrderPlanReportsRepository> _logger;
        public OrderPlanReportsRepository(MaxcoDBContext _dbCon, ILogger<OrderPlanReportsRepository> logger) //: base(_dbCon)
        {
            dbCon = _dbCon;
            _logger = logger;
        }

        //public async Task<WeeklySummaryVM> GetBuyerWiseFabricSummary(DateTime DateFrom, DateTime DateTo, int BuyerID, int OrderID)
        //{
        //    WeeklySummaryVM weeklySummary = new();
        //    try
        //    {
        //        await dbCon.LoadStoredProc("rpt.Plan_BuyerWiseFabricSummary")
        //           .WithSqlParam(nameof(DateFrom), DateFrom)
        //           .WithSqlParam(nameof(DateTo), DateTo)
        //           .WithSqlParam(nameof(BuyerID), BuyerID)
        //           .WithSqlParam(nameof(OrderID), OrderID)
        //           .ExecuteStoredProcAsync((handler) =>
        //           {
        //               weeklySummary.OrderInfo = handler.ReadToList<OrderInfo>() as List<OrderInfo>;
        //               handler.NextResult();

        //               weeklySummary.OrderGreigeFabric = handler.ReadToList<OrderGreigeFabric>() as List<OrderGreigeFabric>;
        //               handler.NextResult();

        //               weeklySummary.OrderFinishFabric = handler.ReadToList<OrderFinishFabric>() as List<OrderFinishFabric>;
        //               handler.NextResult();

        //           });
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //    return weeklySummary;
        //}

        public async Task<PlannedOrderDetailInfoRM> GetGarmentAssortmentAndFabricsInfo(DateTime DateFrom, DateTime DateTo, int BuyerID, int OrderID)
        {
            PlannedOrderDetailInfoRM orderDetail = new();
            try
            {
                await dbCon.LoadStoredProc("rpt.usp_Plan_GarmentAssortmentAndFabricsInfo")
                   .WithSqlParam(nameof(DateFrom), DateFrom)
                   .WithSqlParam(nameof(DateTo), DateTo)
                   .WithSqlParam(nameof(BuyerID), BuyerID)
                   .WithSqlParam(nameof(OrderID), OrderID)
                   .ExecuteStoredProcAsync((handler) =>
                   {
                       orderDetail.FabricInfo = handler.ReadToList<GarmentAssortmentAndFabricsInfoRM>() as List<GarmentAssortmentAndFabricsInfoRM>;
                       handler.NextResult();

                       orderDetail.GreigeFabric = handler.ReadToList<OrderGreigeFabricRM>() as List<OrderGreigeFabricRM>;
                       handler.NextResult();

                       orderDetail.FinishFabric = handler.ReadToList<OrderFinishFabricRM>() as List<OrderFinishFabricRM>;
                       handler.NextResult();

                   });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orderDetail;
        }

        public async Task<PlannedAdditionalInfoRM> GetOrderAdditionalInfo(DateTime DateFrom, DateTime DateTo, int BuyerID, int OrderID)
        {
            PlannedAdditionalInfoRM additionalInfo = new();
            try
            {
                await dbCon.LoadStoredProc("rpt.Usp_Plan_OrderAdditionalInfo")
                   .WithSqlParam(nameof(DateFrom), DateFrom)
                   .WithSqlParam(nameof(DateTo), DateTo)
                   .WithSqlParam(nameof(BuyerID), BuyerID)
                   .WithSqlParam(nameof(OrderID), OrderID)
                   .ExecuteStoredProcAsync((handler) =>
                   {
                       additionalInfo.PlanKnitting = handler.ReadToList<BatchCommitmentRM>() as List<BatchCommitmentRM>;
                       handler.NextResult();
                       additionalInfo.BatchCommitment = handler.ReadToList<BatchCommitmentRM>() as List<BatchCommitmentRM>;
                       handler.NextResult();
                       additionalInfo.DeliveryCommitment = handler.ReadToList<BatchCommitmentRM>() as List<BatchCommitmentRM>;
                       handler.NextResult();
                       additionalInfo.ArtWork = handler.ReadToList<ArtWorkRM>() as List<ArtWorkRM>;
                       handler.NextResult();
                       additionalInfo.DyeingProductionLocation = handler.ReadToList<DyeingProductionLocationRM>() as List<DyeingProductionLocationRM>;

                   });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return additionalInfo;
        }

        //public async Task<OrderStatusVM> GetPlannedOrderStatus(DateTime DateFrom, DateTime DateTo, int BuyerID, int OrderID)
        //{
        //    OrderStatusVM orderStatus = new();
        //    try
        //    {
        //        await dbCon.LoadStoredProc("rpt.Usp_Plan_OrderStatusReport")
        //           .WithSqlParam(nameof(DateFrom), DateFrom)
        //           .WithSqlParam(nameof(DateTo), DateTo)
        //           .WithSqlParam(nameof(BuyerID), BuyerID)
        //           .WithSqlParam(nameof(OrderID), OrderID)
        //           .ExecuteStoredProcAsync((handler) =>
        //           {
        //               orderStatus.AssortmentAndFabrics = handler.ReadToList<Plan_GarmentAssortmentAndFabricsReport>() as List<Plan_GarmentAssortmentAndFabricsReport>;
        //               handler.NextResult();

        //               orderStatus.GreigeQuantity = handler.ReadToList<Plan_OrderGreigeQuantityReport>() as List<Plan_OrderGreigeQuantityReport>;
        //               handler.NextResult();

        //               orderStatus.BatchAndFinishQuantity = handler.ReadToList<Plan_OrderBatchAndFinishQuantityReport>() as List<Plan_OrderBatchAndFinishQuantityReport>;
        //               handler.NextResult();

        //               orderStatus.OrderCommitment = handler.ReadToList<OrderCommitment>() as List<OrderCommitment>;
        //               handler.NextResult();

        //               orderStatus.OrderArtWork = handler.ReadToList<OrderArtWork>() as List<OrderArtWork>;

        //           });
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //    return orderStatus;
        //}

        public async Task<List<PlanArtWorkFabricConsumptionRM>> GetArtWorkPlanDaa(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken)
        {
            var exportWastageQuery = from re in dbCon.Plan_GarmentAssortmentAndFabricsReport
                                     where re.DeliveryDate >= DateFrom && re.DeliveryDate <= DateTo
                                     group re by new { re.BuyerID, re.OrderID, re.StyleID, re.WastagePercent, re.FabricMonth, re.FabricMonthSl, re.DeliveryDate.Year, re.DeliveryDate.Month } into reGrp
                                     select new
                                     {
                                         FabricMonthSl = reGrp.Key.FabricMonthSl,
                                         FabricMonth = reGrp.Key.FabricMonth,
                                         Year = reGrp.Key.Year,
                                         Month = reGrp.Key.Month,
                                         OrderID = reGrp.Key.OrderID,
                                         BuyerID = reGrp.Key.BuyerID,
                                         StyleID = reGrp.Key.StyleID,
                                         WastagePercent = reGrp.Key.WastagePercent
                                     };
            if (OrderID > 0)
            {
                exportWastageQuery = exportWastageQuery.Where(b => b.OrderID == OrderID);
            }

            if (BuyerID > 0)
            {
                exportWastageQuery = exportWastageQuery.Where(b => b.BuyerID == BuyerID);
            }
            var aa = DateTime.Now.ToString("yyyyMM");

            var dataQuery = from v in dbCon.Vw_PlanOrderVersionMax
                            join sf in dbCon.Plan_StyleFabrics on v.PlanVersionID equals sf.PlanVersionID
                            join artFab in dbCon.Plan_FabricArtWork on new { p1 = sf.StyleFabricsID, p2 = true, p3 = false }
                                                      equals new { p1 = artFab.StyleFabricsID, p2 = artFab.IsActive, p3 = artFab.IsRemoved }
                            join artItem in dbCon.Plan_ArtWork_Setup on artFab.ArtWorkID equals artItem.ArtWorkID
                            join fabWas in exportWastageQuery on new { j1 = sf.StyleID, j2 = artFab.ArtWorkDate.Year, j3 = artFab.ArtWorkDate.Month }
                                                          equals new { j1 = fabWas.StyleID, j2 = fabWas.Year, j3 = fabWas.Month }
                            where artFab.ArtWorkDate > DateFrom && artFab.ArtWorkDate <= DateTo
                            group new { fabWas, v, artItem, artFab, sf } by new
                            {
                                fabWas.FabricMonth,
                                fabWas.FabricMonthSl,
                                fabWas.WastagePercent,
                                v.BuyerID,
                                v.Buyer,
                                v.OrderID,
                                v.OrderNo,
                                artItem.ArtWorkName
                            } into grp
                            select new PlanArtWorkFabricConsumptionRM
                            {
                                FabricMonthSl = grp.Key.FabricMonthSl,
                                FabricMonth = grp.Key.FabricMonth,
                                BuyerID = grp.Key.BuyerID,
                                Buyer = grp.Key.Buyer,
                                OrderID = grp.Key.OrderID,
                                OrderNo = grp.Key.OrderNo,
                                //StyleID = sf.StyleID,
                                ArtwarkName = grp.Key.ArtWorkName,
                                //ShipmentDate = artFab.ArtWorkDate,
                                ArtQuantity = grp.Sum(s => s.artFab.ArtWorkQuantity),
                                OrderMainArtWorkFinishKg = grp.Sum(s => s.artFab.ArtWorkQuantity * (s.sf.MainFabricUseConsumption)),
                                OrderRibArtWorkFinishKg = grp.Sum(s => s.artFab.ArtWorkQuantity * (s.sf.RibUseConsumption)),
                                OrderTotalArtWorkFinishKg = grp.Sum(s => s.artFab.ArtWorkQuantity * (s.sf.MainFabricUseConsumption + s.sf.RibUseConsumption)),
                                WastagePercent = grp.Key.WastagePercent
                                //Pantone = sf.PantoneNo,
                                //MainFabricConsumption = sf.MainFabricUseConsumption,
                                //RibConsumption = sf.RibUseConsumption,
                                //TotalFabricConsumption =sf.MainFabricUseConsumption+sf.RibUseConsumption,

                            };
            //var q = dataQuery.ToQueryString();

            return await dataQuery.OrderBy(b => b.FabricMonthSl).ThenBy(t => t.BuyerID).ToListAsync(cancellationToken);
        }
        public async Task Plan_GenerateReportData_Schedue()
        {
            try
            {

                await dbCon.LoadStoredProc("rpt.Usp_Plan_GenerateReportData_Schedue",commandTimeout:500)
                       .ExecuteStoredNonQueryAsync();
                _logger.LogInformation("OrderPlanReportsRepository function Plan_GenerateReportData_Schedue");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "OrderPlanReportsRepository function Plan_GenerateReportData_Schedue");
            }
        }

        public IQueryable<Plan_OrderGreigeQuantityReport> GetPlan_OrderGreigeQuantityReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID)
        {
            var query = dbCon.Plan_OrderGreigeQuantityReport.Where(b => (BuyerID == 0 || b.BuyerID == BuyerID));
            if (OrderID > 0)
            {
                query = query.Where(b => b.OrderID == OrderID);
            }
            return query;

        }

        public IQueryable<Plan_OrderBatchAndFinishQuantityReport> GetPlan_OrderBatchAndFinishQuantityReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID)
        {
            var query = dbCon.Plan_OrderBatchAndFinishQuantityReport.Where(b => (BuyerID == 0 || b.BuyerID == BuyerID));
            if (OrderID > 0)
            {
                query = query.Where(b => b.OrderID == OrderID);
            }
            return query; ;
        }

        public async Task<List<DyeingUnitProductionFabricWeekRM>> GetDyeingProductionFinishFabricWeek(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken)
        {
            var exportWastageQuery = from re in dbCon.Plan_GarmentAssortmentAndFabricsReport
                                     where re.DeliveryDate >= DateFrom && re.DeliveryDate <= DateTo
                                     select new DyeingUnitProductionFabricWeekRM
                                     {
                                         MonthSl = re.FabricMonthSl,
                                         FabricWeek = re.FabricWeek,
                                         OrderID = re.OrderID,
                                         BuyerID = re.BuyerID,
                                         Buyer = re.BuyerName,
                                         StyleID = re.StyleID,
                                         OrderQty = re.NumberofGarments,
                                         FabricBookingKg = re.NumberofGarments * (re.MainFabricUseConsumption + re.RibUseConsumption),
                                         DyeingWastagePercentage = re.WastagePercent,

                                     };
            if (OrderID > 0)
            {
                exportWastageQuery = exportWastageQuery.Where(b => b.OrderID == OrderID);
            }

            if (BuyerID > 0)
            {
                exportWastageQuery = exportWastageQuery.Where(b => b.BuyerID == BuyerID);
            }
            var aa = DateTime.Now.ToString("yyyyMM");

            var dataQuery = from wf in exportWastageQuery
                            join _pv in dbCon.Vw_PlanOrderVersionMax on wf.OrderID equals _pv.OrderID into _wfGv
                            from pv in _wfGv.DefaultIfEmpty()
                            join _sf in dbCon.Plan_StyleFabrics on new { p1 = (int)wf.StyleID, p2 = pv.PlanVersionID, p3 = true, p4 = false }
                                                            equals new { p1 = _sf.StyleID, p2 = _sf.PlanVersionID, p3 = _sf.IsActive, p4 = _sf.IsRemoved } into _sfGrp
                            from sf in _sfGrp.DefaultIfEmpty()
                            join _deyFab in dbCon.Plan_DyeingProduction on new { p1 = sf.StyleFabricsID, p2 = true, p3 = false }
                                                                    equals new { p1 = _deyFab.StyleFabricsID, p2 = _deyFab.IsActive, p3 = _deyFab.IsRemoved } into _deyfab
                            from deyFab in _deyfab.DefaultIfEmpty()
                            join _dCat in dbCon.Plan_DyeingProductionLocation_Setup on deyFab.DyeingProductionID equals _dCat.ProductionLocationID into _dCatGrp
                            from dCat in _dCatGrp.DefaultIfEmpty()
                            group new { deyFab, wf, dCat } by new { wf.FabricWeek, wf.MonthSl, wf.OrderID, wf.Buyer, wf.BuyerID, dCat.LocationName } into grpF
                            select new DyeingUnitProductionFabricWeekRM
                            {
                                FabricWeek = grpF.Key.FabricWeek,
                                MonthSl = grpF.Key.MonthSl,
                                OrderID = grpF.Key.OrderID,
                                Buyer = grpF.Key.Buyer,
                                BuyerID = grpF.Key.BuyerID,
                                DyeingProductinUnit = grpF.Key.LocationName == null ? "NS" : grpF.Key.LocationName,
                                DyeingPlanKg = grpF.Sum(s => s.deyFab.ProductionQuantity),
                                OrderQty = grpF.Sum(s => s.wf.OrderQty),
                                FabricBookingKg = grpF.Sum(s => s.wf.FabricBookingKg)
                            };
            /*
            from
            v in dbCon.Vw_PlanOrderVersionMax
            join sf in dbCon.Plan_StyleFabrics on v.PlanVersionID equals sf.PlanVersionID
            join artFab in dbCon.Plan_FabricArtWork on new { p1 = sf.StyleFabricsID, p2 = true, p3 = false }
                                      equals new { p1 = artFab.StyleFabricsID, p2 = artFab.IsActive, p3 = artFab.IsRemoved }
            join artItem in dbCon.Plan_ArtWork_Setup on artFab.ArtWorkID equals artItem.ArtWorkID
            join fabWas in exportWastageQuery on new { j1 = sf.StyleID, j2 = artFab.ArtWorkDate.Year, j3 = artFab.ArtWorkDate.Month }
                                          equals new { j1 = fabWas.StyleID, j2 = fabWas.Year, j3 = fabWas.Month }
            where artFab.ArtWorkDate > DateFrom && artFab.ArtWorkDate <= DateTo
            group new { fabWas, v, artItem, artFab, sf } by new
            {
                fabWas.FabricMonth,
                fabWas.FabricMonthSl,
                fabWas.WastagePercent,
                v.BuyerID,
                v.Buyer,
                v.OrderID,
                v.OrderNo,
                artItem.ArtWorkName
            } into grp
            select new PlanArtWorkFabricConsumptionRM
            {
                FabricMonthSl = grp.Key.FabricMonthSl,
                FabricMonth = grp.Key.FabricMonth,
                BuyerID = grp.Key.BuyerID,
                Buyer = grp.Key.Buyer,
                OrderID = grp.Key.OrderID,
                OrderNo = grp.Key.OrderNo,
                //StyleID = sf.StyleID,
                ArtwarkName = grp.Key.ArtWorkName,
                //ShipmentDate = artFab.ArtWorkDate,
                ArtQuantity = grp.Sum(s => s.artFab.ArtWorkQuantity),
                OrderMainArtWorkFinishKg = grp.Sum(s => s.artFab.ArtWorkQuantity * (s.sf.MainFabricUseConsumption)),
                OrderRibArtWorkFinishKg = grp.Sum(s => s.artFab.ArtWorkQuantity * (s.sf.RibUseConsumption)),
                OrderTotalArtWorkFinishKg = grp.Sum(s => s.artFab.ArtWorkQuantity * (s.sf.MainFabricUseConsumption + s.sf.RibUseConsumption)),
                WastagePercent = grp.Key.WastagePercent
                //Pantone = sf.PantoneNo,
                //MainFabricConsumption = sf.MainFabricUseConsumption,
                //RibConsumption = sf.RibUseConsumption,
                //TotalFabricConsumption =sf.MainFabricUseConsumption+sf.RibUseConsumption,

            };
            */
            var q = dataQuery.ToQueryString();

            return await dataQuery.OrderBy(b => b.MonthSl)
                  .ThenBy(t => t.BuyerID)
                  .ThenBy(b=>b.FabricWeek)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<GreigeFabricPlanRM>> GetPlanGreigeFabricReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken)
        {
            List<GreigeFabricPlanRM> greigePlan = new();
            try
            {
                await dbCon.LoadStoredProc("rpt.Plan_GreigeFabric")
                   .WithSqlParam(nameof(DateFrom), DateFrom)
                   .WithSqlParam(nameof(DateTo), DateTo)
                   .WithSqlParam(nameof(BuyerID), BuyerID)
                   .WithSqlParam(nameof(OrderID), OrderID)
                   .ExecuteStoredProcAsync((handler) =>
                   {
                       greigePlan = handler.ReadToList<GreigeFabricPlanRM>() as List<GreigeFabricPlanRM>;
                      
                   });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return greigePlan;
        }

        public async Task<List<DailyBatchRM>> GetDailyBatchReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken)
        {
            List<DailyBatchRM> dailyBatch = new();
            try
            {
                await dbCon.LoadStoredProc("rpt.Plan_DailyBatch")
                   .WithSqlParam(nameof(DateFrom), DateFrom)
                   .WithSqlParam(nameof(DateTo), DateTo)
                   .WithSqlParam(nameof(BuyerID), BuyerID)
                   .WithSqlParam(nameof(OrderID), OrderID)
                   .ExecuteStoredProcAsync((handler) =>
                   {
                       dailyBatch = handler.ReadToList<DailyBatchRM>() as List<DailyBatchRM>;

                   });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dailyBatch;
        }

        public  async Task<List<FinishFabricDeliveryRM>> GetDailyFinishFabricDeliveryReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken)
        {
            List<FinishFabricDeliveryRM> floorStatus = new();
            try
            {
                await dbCon.LoadStoredProc("rpt.Plan_FinishFabricDelivery")
                   .WithSqlParam(nameof(DateFrom), DateFrom)
                   .WithSqlParam(nameof(DateTo), DateTo)
                   .WithSqlParam(nameof(BuyerID), BuyerID)
                   .WithSqlParam(nameof(OrderID), OrderID)
                   .ExecuteStoredProcAsync((handler) =>
                   {
                       floorStatus = handler.ReadToList<FinishFabricDeliveryRM>() as List<FinishFabricDeliveryRM>;

                   });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return floorStatus;
        }

        public async Task<List<FabricFloorStatusRM>> GetFabricFloorStatusReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken)
        {
            List<FabricFloorStatusRM> finishfabric = new();
            try
            {
                await dbCon.LoadStoredProc("rpt.Plan_FabricFloorStatus")
                   .WithSqlParam(nameof(DateFrom), DateFrom)
                   .WithSqlParam(nameof(DateTo), DateTo)
                   .WithSqlParam(nameof(BuyerID), BuyerID)
                   .WithSqlParam(nameof(OrderID), OrderID)
                   .ExecuteStoredProcAsync((handler) =>
                   {
                       finishfabric = handler.ReadToList<FabricFloorStatusRM>() as List<FabricFloorStatusRM>;

                   });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return finishfabric;
        }

        public async Task<List<DailyPrintProductionRM>> GetDailyPrintProductionSummeryReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken)
        {
            List<DailyPrintProductionRM> floorStatus = new();
            try
            {
                await dbCon.LoadStoredProc("rpt.Plan_DailyPrintProduction")
                   .WithSqlParam(nameof(DateFrom), DateFrom)
                   .WithSqlParam(nameof(DateTo), DateTo)
                   .WithSqlParam(nameof(BuyerID), BuyerID)
                   .WithSqlParam(nameof(OrderID), OrderID)
                   .ExecuteStoredProcAsync((handler) =>
                   {
                       floorStatus = handler.ReadToList<DailyPrintProductionRM>() as List<DailyPrintProductionRM>;

                   });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return floorStatus;
        }

        public async Task<List<PlanUsedFabricCuttingSectionRM>> GetUsedFabricCuttingSection(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken)
        {
            List<PlanUsedFabricCuttingSectionRM> floorStatus = new();
            try
            {
                await dbCon.LoadStoredProc("rpt.Plan_DailyUsedFabricCuttingSection")
                   .WithSqlParam("DateFrom", DateFrom)
                   .WithSqlParam("DateTo", DateTo)
                   .WithSqlParam("BuyerID", BuyerID)
                   .WithSqlParam("OrderID", OrderID)
                   .ExecuteStoredProcAsync((handler) =>
                   {
                       floorStatus = handler.ReadToList<PlanUsedFabricCuttingSectionRM>() as List<PlanUsedFabricCuttingSectionRM>;

                   });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return floorStatus;
        }

        public async Task<List<ManagementStatusRM>> GetManagementStatusReport(DateTime DateFrom, DateTime DateTo, int BuyerID, long OrderID, CancellationToken cancellationToken)
        {
            List<ManagementStatusRM> managementStatus = new();
            try
            {
                await dbCon.LoadStoredProc("rpt.Plan_OrderFabricManagementStatus")
                   .WithSqlParam("DateFrom", DateFrom)
                   .WithSqlParam("DateTo", DateTo)
                   .WithSqlParam("BuyerID", BuyerID)
                   .WithSqlParam("OrderID", OrderID)
                   .ExecuteStoredProcAsync((handler) =>
                   {
                       managementStatus = handler.ReadToList<ManagementStatusRM>() as List<ManagementStatusRM>;
                   });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return managementStatus;
        }
    }
}
