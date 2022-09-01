using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.Embro.CompanyInfos.Queries;
using RG.Application.Contracts.EMS.Business.ExportDocuments.Queries;
using RG.Application.ViewModel.EMS.Business.ShipmentReport;
using RG.Application.ViewModel.MDSir.ExportDocument;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.MDSir.Controllers
{
    [Area("MDSir")]
    [Route("MDSir/[controller]/[action]")]
    [AllowAnonymous]
    public class ExportDocumentController : BaseController
    {
        private readonly IDropdownService _dropdownService;

        public ExportDocumentController(IDropdownService dropdownService)
        {
            _dropdownService = dropdownService;
        }
        public async Task<IActionResult> ExportDocumentRealization()
        {
            var data = await Mediator.Send(new GetExportDocumentRealizationDataQuery { IsDetailsReport = 0 });
            return View(data);
        }
        public async Task<IActionResult> ExportDocumentRealizationDetail(int FDBPP_ID)
        {
            var data = await Mediator.Send(new GetExportDocumentRealizationDataQuery { IsDetailsReport = 1,FDBPP_ID= FDBPP_ID });
            return View(data);
        }
        public async Task<IActionResult> LCMaturityRealization()
        {           
            var ddlFilter = new List<SelectListItem>
            {
                new SelectListItem{Text="Date",Value="1"},
                new SelectListItem{Text="Month",Value="2"},
                new SelectListItem{Text="Year",Value="3"}
            };
            var ddlFundType = new List<SelectListItem>
            {
                new SelectListItem{Text="Please Select",Value=""},
                new SelectListItem{Text="EDF",Value="1"},
                new SelectListItem{Text="Deffered",Value="2"}                
            };

            var model = new LCMaturityRealizationVM
            {
                DDLFilterType = ddlFilter,
                DDLMonth = _dropdownService.DDLMonth(),
                DDLYear = _dropdownService.NumberDDL(DateTime.Now.Year - 2, DateTime.Now.Year, false),
                DDLCompany = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), true),
                DDLFundType = ddlFundType,
                Month=DateTime.Now.Month,
                Year=DateTime.Now.Year,
                FilterTypeID=2,
                DateFrom=DateTime.Now.ToString("dd-MMM-yyyy"),
                DateTo = DateTime.Now.ToString("dd-MMM-yyyy"),
            };
           
            return View(model);
        }
        public async Task<IActionResult> LCMaturityRealizationReport(int FilterTypeId , DateTime DateFrom ,DateTime DateTo ,int Month , int Year, int CompanyId = 0, int FundTypeID = 0)
        {
            var reportType = $"Date Wise Report <br/> From {DateFrom:dd-MMM-yyyy} to {DateTo:dd-MMM-yyyy}";
            if (FilterTypeId == 2)
            {                
                reportType = $"Monthly Report <br/>For the month of: {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Month)}-{DateTime.Now.Year}";
            }
            else if (FilterTypeId == 3)
            {
                reportType = $"Yearly Report <br/> For The Year: {Year}";
            }
            else { 
            }
            ViewBag.ReportType = reportType;            
            var data = await Mediator.Send(new GetLCMaturityRealizeQuery {FilterTypeId=FilterTypeId,DateFrom=DateFrom,DateTo=DateTo,Month=Month,Year=Year,CompanyId=CompanyId,FundTypeID=FundTypeID });
                        
            return View(data);
        }
        public async Task<IActionResult> OutstandingLCRealization()
        {
            var ddlFundType = new List<SelectListItem>
            {
                new SelectListItem{Text="Please Select",Value=""},
                new SelectListItem{Text="EDF",Value="1"},
                new SelectListItem{Text="Deffered",Value="2"}
            };

            var model = new LCMaturityRealizationVM
            {
                
                DDLMonth = _dropdownService.DDLMonth(),
                DDLYear = _dropdownService.NumberDDL(2021, DateTime.Now.Year, false),
                DDLCompany = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), true),                
                Year = DateTime.Now.Year,
                DDLFundType = ddlFundType
            };

            return View(model);
        }
        public async Task<IActionResult> OutstandingLCRealizationReport(int Year, int CompanyId = 0, int FundTypeID = 0)
        {
            var data = await Mediator.Send(new GetOutstandingLCRealizationQuery {Year = Year, CompanyId = CompanyId, FundTypeID = FundTypeID });
            var reportType = $"Report From Year {Year}";
            ViewBag.ReportType = reportType;
            return View(data);
        }

        [AllowAnonymous]
        public IActionResult WeeklyShipmentStatus()
        {
            var model = new WeeklyShipmentStatusVM
            {
                DDLYear = _dropdownService.NumberDDL(2022, DateTime.Now.Year, false),
                DDLMonth = _dropdownService.DDLMonth(),
                DDLWeek = _dropdownService.DefaultDDL(),
                Year = DateTime.Now.Year
            };
            return View(model);
        }
    }
    
}
