using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries;
using RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel;
using RG.Application.Contracts.Maxco.Buisness.Plan_OrderMasters.Queries;
using RG.Application.Contracts.Maxco.Setup.Buyer_Setup.Queries;
using RG.Application.ViewModel.Maxco.Business.OrderPlanReports;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.Maxco.Controllers
{
    [Area("Maxco")]
    [Route("Maxco/[controller]/[action]")]
    public class OrderPlanReportsController : BaseController
    {
        private readonly IDropdownService dropdownService;

        public OrderPlanReportsController(IDropdownService _dropdownService)
        {
            dropdownService = _dropdownService;
        }
        public async Task<IActionResult> Index()
        {
            var model = new IndexVM()
            {
                DDLReportType = dropdownService.RenderDDL(GetDDLReportTypes(), true),
                DDLBuyer = dropdownService.RenderDDL(await Mediator.Send(new GetDDLBuyerAllQuery() { }))
            };
            var _dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            model.DateFrom = _dateTime.ToString("dd-MMM-yyyy");
            model.DateTo = _dateTime.AddMonths(1).AddDays(-1).ToString("dd-MMM-yyyy");
            return View(model);
        }
        private static List<SelectListItem> GetDDLReportTypes()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Text="1. Order Status",Value="OS" },//1
                new SelectListItem{Text="2. Fabric Type Wise Order Status",Value="FTWOS" },//2
                new SelectListItem{Text="3. Buyer Wise Status",Value="BWS" },//3
                new SelectListItem{Text="4. Order Wise Status",Value="OWS" },//4
                new SelectListItem{Text="5. Week Wise Status",Value="WWS" },//5
                new SelectListItem{Text="6. Weekly Summary",Value="WS" },//6
                new SelectListItem{Text="7. Art Work Fabric Summary",Value="AWFS" },//7
                new SelectListItem{Text="8. Dyeing Unit Finish Fabric",Value="DUFF" },//8
                new SelectListItem{Text="9. Grey Fabric WIP",Value="PGF" },//report 9
                new SelectListItem{Text="10. Plan New Order",Value="PNO" },//report 10
                new SelectListItem{Text="11. Daily Batch Report",Value="DBR" },//report 11
                new SelectListItem{Text="14. Daily Finish Fabric Delivery",Value="DFFD" },//report 14
                new SelectListItem{Text="18. Floor Fabric Status",Value="FFS" },//report 18
                new SelectListItem{Text="22. Daily Print Production Summary",Value="DPPS" }, //report 22
                new SelectListItem{Text="23. Daily Used Fabric Status",Value="DUFS" }, //report 23-24
                new SelectListItem{Text="24. Fabric Status Of Cutting Setion",Value="FSCS" },
                new SelectListItem{Text="25. Management Status Report",Value="MSR" },
            };
        }


        #region Report 1
        public async Task<IActionResult> OrderStatusDetail(DateTime dateFrom, DateTime dateTo, int buyerID = 0, int orderID = 0)
        {
            var model = await Mediator.Send(new GetPlannedOrderStatusQuery() { DateFrom = dateFrom, DateTo = dateTo, BuyerID = buyerID, OrderID = orderID });
            return View(model);
        }
        #endregion

        #region Report 2
        public async Task<IActionResult> FabricTypeWiseOrderStatus(DateTime dateFrom, DateTime dateTo, int buyerID = 0, int orderID = 0)
        {
            var model = await Mediator.Send(new GetFabricTypeWiseOrderStatusReportQuery() { DateFrom = dateFrom, DateTo = dateTo, BuyerID = buyerID, OrderID = orderID });
            return View(model);
        }
        #endregion

        #region Report 3
        public async Task<IActionResult> BuyerWiseStatus(DateTime dateFrom, DateTime dateTo, int buyerID = 0, int orderID = 0)
        {
            var model = await Mediator.Send(new GetBuyerWiseStatusReportQuery() { DateFrom = dateFrom, DateTo = dateTo, BuyerID = buyerID, OrderID = orderID });
            return View(model);
        }
        #endregion

        #region Report 4
        public async Task<IActionResult> OrderWiseStatus(DateTime dateFrom, DateTime dateTo, int buyerID = 0, int orderID = 0)
        {
            var model = await Mediator.Send(new GetOrderWiseStatusReportQuery() { DateFrom = dateFrom, DateTo = dateTo, BuyerID = buyerID, OrderID = orderID });
            return View(model);
        }
        #endregion

        #region Report 5
        public async Task<IActionResult> WeekWiseStatus(DateTime dateFrom, DateTime dateTo, int buyerID = 0, int orderID = 0)
        {
            var model = await Mediator.Send(new GetWeekWiseStatusReportQuery() { DateFrom = dateFrom, DateTo = dateTo, BuyerID = buyerID, OrderID = orderID });
            return View(model);
        }
        #endregion

        #region Report 6 Weak Summary
        public async Task<IActionResult> WeeklySummary(DateTime dateFrom, DateTime dateTo, int buyerID = 0, int orderID = 0)
        {
            var model = await Mediator.Send(new GetBuyerWiseFabricSummaryQuery() { DateFrom = dateFrom, DateTo = dateTo, BuyerID = buyerID, OrderID = orderID });
            return View(model);
        }
        #endregion

        #region Report 7 Art work 
        public async Task<IActionResult> ArtWorkPlanSummary(DateTime dateFrom, DateTime dateTo, int buyerID = 0, int orderID = 0)
        {
            var model = await Mediator.Send(new ArtWorkPlanSummaryQuery() { DateFrom = dateFrom, DateTo = dateTo, BuyerID = buyerID, OrderID = orderID });
            return View(model);
        }
        #endregion

        #region Report 8 Dyeing Production Week  Wise Finish Fabric
        public async Task<IActionResult> DyeingProductionFinishFabricWeekReport(DateTime dateFrom, DateTime dateTo, int buyerID = 0, int orderID = 0)
        {
            var model = await Mediator.Send(new GetDyeingProductionFinishFabricWeekQuery() { DateFrom = dateFrom, DateTo = dateTo, BuyerID = buyerID, OrderID = orderID });
            return View(model);
        }
        #endregion

        #region Report 9 Plan Greige Fabric
        public async Task<IActionResult> GreyFabricWip(DateTime dateFrom, DateTime dateTo, int buyerID = 0, int orderID = 0)
        {
            var model = await Mediator.Send(new GetPlanGreigeFabricReportQuery() { DateFrom = dateFrom, DateTo = dateTo, BuyerID = buyerID, OrderID = orderID });
            return View(model);
        }

        //

        #endregion

        #region Report 10  Plan new Order
        public async Task<IActionResult> PlanNewOrder(DateTime dateFrom, DateTime dateTo, int buyerID = 0, int orderID = 0)
        {
            var model = await Mediator.Send(new GetPlanNewOrderQuery() { DateFrom = dateFrom, DateTo = dateTo, BuyerID = buyerID, OrderID = orderID });
            return View(model);
        }

        //

        #endregion

        #region Report 11 Daily Batch Report
        public async Task<IActionResult> DailyBatchReport(DateTime dateFrom, DateTime dateTo, int buyerID = 0, int orderID = 0)
        {
            var model = await Mediator.Send(new GetDailyBatchReportQuery() { DateFrom = dateFrom, DateTo = dateTo, BuyerID = buyerID, OrderID = orderID });
            return View(model);
        }
        #endregion

        #region Report 14 Daily Finish Fabric Delivery Report
        public async Task<IActionResult> DailyFinishFabricDeliveryReport(DateTime dateFrom, DateTime dateTo, int buyerID = 0, int orderID = 0)
        {
            var model = await Mediator.Send(new GetDailyFinishFabricDeliveryReportQuery() { DateFrom = dateFrom, DateTo = dateTo, BuyerID = buyerID, OrderID = orderID });
            return View(model);
        }

        //GetDailyBatchReportQuery
        #endregion

        #region Report 18  Plan new Order
        public async Task<IActionResult> PlanFloorStatus(DateTime dateFrom, DateTime dateTo, int buyerID = 0, int orderID = 0)
        {
            var model = await Mediator.Send(new GetFabricFloorStatusReportQuery() { DateFrom = dateFrom, DateTo = dateTo, BuyerID = buyerID, OrderID = orderID });
            return View(model);
        }

        #endregion

        #region Report 22 Daily Print Production Summery
        public async Task<IActionResult> DailyPrintProductionSummery(DateTime dateFrom, DateTime dateTo, int buyerID = 0, int orderID = 0)
        {
            var model = await Mediator.Send(new GetDailyPrintProductionSummeryQuery() { DateFrom = dateFrom, DateTo = dateTo, BuyerID = buyerID, OrderID = orderID });
            return View(model);
        }

        #endregion
        #region Report 25 Management Status Report
        public async Task<IActionResult> ManagementStatusReport(DateTime dateFrom, DateTime dateTo, int buyerID = 0, int orderID = 0)
        {
            var model = await Mediator.Send(new GetManagementStatusReportQuery() { DateFrom = dateFrom, DateTo = dateTo, BuyerID = buyerID, OrderID = orderID });
            return View(model);
        }

        #endregion
        public async Task<JsonResult> DDLBuyerWisePlanOrders(int buyerID, string predict)
        {
            var data = dropdownService.RenderDDL(await Mediator.Send(new GetDDLBuyerWisePlanOrdersQuery { BuyerID = buyerID, IsOrderClosed = null, Predict = predict }), false);
            return Json(data);
        }

        public async Task<IActionResult> DailyUsedFabricStatus(DateTime dateFrom, DateTime dateTo, int buyerID = 0, int orderID = 0)
        {
            var model = await Mediator.Send(new GetUsedFabricCuttingSectionQuery() { DateFrom = dateFrom, DateTo = dateTo, BuyerID = buyerID, OrderID = orderID });
            var rData = model
                .GroupBy(s => new { s.MonthSL, s.MonthYear,s.Productiondate })
                .Select(s => new PlanUsedFabricCuttingSectionRM()
                {
                    MonthSL = s.Key.MonthSL,
                    MonthYear =s.Key.MonthYear,
                    Productiondate = s.Key.Productiondate,
                    RollWeight = s.Sum(d=>d.RollWeight),
                    TotalCuttingQty = s.Sum(d=>d.TotalCuttingQty),
                    InputQty = s.Sum(d=>d.InputQty)
                }).ToList();


            return View(rData);
        }
        public async Task<IActionResult> FabricsStatusOfCuttingSection(DateTime dateFrom, DateTime dateTo, int buyerID = 0, int orderID = 0)
        {
            var _model = await Mediator.Send(new GetUsedFabricCuttingSectionQuery() { DateFrom = dateFrom, DateTo = dateTo, BuyerID = buyerID, OrderID = orderID });

            var rData = _model
                .GroupBy(s => new { s.MonthSL, s.MonthYear, s.Productiondate })
                .Select(s => new PlanUsedFabricCuttingSectionRM()
                {
                    MonthSL = s.Key.MonthSL,
                    MonthYear = s.Key.MonthYear,
                    Productiondate = s.Key.Productiondate,
                    RollWeight = s.Sum(d => d.RollWeight),
                    TotalCuttingQty = s.Sum(d => d.TotalCuttingQty),
                    InputQty = s.Sum(d => d.InputQty)
                }).ToList();


            return View(rData);
        }
    }
}
