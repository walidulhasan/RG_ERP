using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Constants;
using RG.Application.Contracts.Embro.CompanyInfos.Queries;
using RG.Application.Contracts.EMS.Business.ExportDocuments.Queries;
using RG.Application.Contracts.EMS.Setups.bl_Periods.Queries;
using RG.Application.Contracts.Maxco.Setup.Buyer_Setup.Queries;
using RG.Application.Enums;
using RG.Application.ViewModel.EMS.Business.ShipmentReport;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RG.WEB.Areas.EMS.Controllers
{
    [Area("EMS")]
    [Route("EMS/[controller]/[action]")]
    public class ShipmentReportController : BaseController
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDropdownService _dropdownService;

        public ShipmentReportController(ICurrentUserService currentUserService, IDropdownService dropdownService)
        {
            _currentUserService = currentUserService;
            _dropdownService = dropdownService;
        }
       [AllowAnonymous]
        public async Task<IActionResult> OrderShipmentDetails()
        {
            var model = new OrderShipmentDetailsVM
            {
                DDLCompany = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), true),
                DDLBuyer = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLBuyerAllQuery() { }), true)
            };
            var dateTime = DateTime.Now;
            model.DateFrom = new DateTime(dateTime.Year, dateTime.Month, 1).ToString("dd-MMM-yyyy");
            model.DateTo = dateTime.ToString("dd-MMM-yyyy");
            model.CompanyID = _currentUserService.CompanyID;
            return View(model);
        }
        [AllowAnonymous]
        public async Task<IActionResult> OrderShipmentDetailsReport(int CompanyID, int BuyerID, int OrderID, DateTime DateFrom, DateTime DateTo, string ReportFormat = "PDF")
        {

            string reportName = $"/{ReportFolder.EMSFolder}/";

            reportName += "OrderShipmentDetails";
            IDictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("CompanyID", CompanyID);
            parameters.Add("BuyerID", BuyerID);
            parameters.Add("OrderID", OrderID);
            parameters.Add("DateFrom", DateFrom.ToString("dd-MMM-yyyy"));
            parameters.Add("DateTo", DateTo.ToString("dd-MMM-yyyy"));


            int connectionString = (int)enum_ServerType.EMSConnection;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

        }
        [AllowAnonymous]
        public async Task<IActionResult> WeeklyExportDetails()
        {
            var model = new WeeklyExportDetailsVM
            {
                DDLCompany = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), true),
                DDLBuyer = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLBuyerAllQuery() { }), true),
                ExFactoryDateFrom = DateTime.Now.ToString("dd-MMM-yyyy"),
                ExFactoryDateTo = DateTime.Now.ToString("dd-MMM-yyyy"),
                CompanyID = _currentUserService.CompanyID,
                DDLReportType = GetReportTypes()
            };


            return View(model);
        }
        [AllowAnonymous]
        public async Task<IActionResult> DocumentPurchasePercent()
        {
            DocumentPurchasePercentVM model = new();
            return View(model);
        }

        private List<SelectListItem> GetReportTypes()
        {
            var data = new List<SelectListItem>()
            {
                new SelectListItem() { Text="Buyer Wise",Value="1"}
            };
            return _dropdownService.RenderDDL(data, true);

        }
        [AllowAnonymous]
        public async Task<IActionResult> WeeklyExportDetailsReport(DateTime exFactoryDateFrom, DateTime exFactoryDateTo, int companyID, int buyerID, int orderID)
        {
            var model = await Mediator.Send(new GetWeeklyExportDetailsReporQuery { ExFactoryDateFrom = exFactoryDateFrom, ExFactoryDateTo = exFactoryDateTo, CompanyID = companyID, BuyerID = buyerID, OrderID = orderID });
            ViewBag.CompanyID = companyID;
            return View(model);
        }
        public ActionResult PaymentNotReceivedWithinExpectedDate()
        {
            var model = new PaymentNotReceivedWithinExpectedDateVM();
            return View(model);
        }
        [AllowAnonymous]
        public async Task<IActionResult> PaymentNotReceivedWithinExpectedDateReport(DateTime exFactoryDateTo)
        {
            var model = await Mediator.Send(new GetPaymentNotReceivedWithinExpectedDateReportQuery { ExFactoryDateTo = exFactoryDateTo});
            
            return View(model);
        }
        [AllowAnonymous]
        public IActionResult WeeklyShipmentStatus()
        {
            var model = new WeeklyShipmentStatusVM
            {
                DDLYear = _dropdownService.NumberDDL(2022, DateTime.Now.Year, false),
                DDLMonth = _dropdownService.DDLMonth(),
                DDLWeek= _dropdownService.DefaultDDL() ,
                Year=DateTime.Now.Year
            };
            return View(model);
        }
        [AllowAnonymous]
        public async Task<IActionResult> WeeklyShipmentStatusReport(int Year, int Month, int Week)
        {
            var model = await Mediator.Send(new GetWeeklyShipmentStatusReportQuery { Year = Year, Month = Month, Week = Week });

            return View(model);

        }
        [AllowAnonymous]
        public async Task<JsonResult> GetDDLWeekPeriod(int year,int month)
        {
            var data = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLWeekPeriodQuery { Year = year, Month = month }),true);
            return Json(data);                 
        }
        [AllowAnonymous]
        public async Task<IActionResult> DocumentPurchasePercentReport(DateTime? dateFrom,DateTime? dateTo, bool withPurchaseRatio=false)
        {
            var data = await Mediator.Send(new GetDocumentsPurchaseRatioQuery { DateFrom = dateFrom, DateTo = dateTo,WithPurchaseRatio=withPurchaseRatio });
            return View(data);
        }


    }
}
