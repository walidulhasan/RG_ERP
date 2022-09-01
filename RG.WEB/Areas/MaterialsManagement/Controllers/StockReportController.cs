using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.MaterialsManagement.Business.YarnStockReport.Queries;
using RG.Application.Contracts.MaterialsManagement.Business.YarnStockReport.RequestResponseModel;
using RG.Application.ViewModel.MaterialsManagement.Business.YarnStockReports;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RG.WEB.Areas.MaterialsManagement.Controllers
{
    [Area("MaterialsManagement")]
    [Route("MaterialsManagement/[controller]/[action]")]
    public class StockReportController : BaseController
    {
        private readonly IDropdownService _dropdownService;

        public StockReportController(IDropdownService dropdownService)
        {
            _dropdownService = dropdownService;
        }
        public IActionResult StockReports()
        {
            List<SelectListItem> ReportType = new()
            {
                new SelectListItem { Text = "Please Select", Value = "0" },
                new SelectListItem { Text = "Yarn Summary", Value = "1" },
                new SelectListItem { Text = "Rack Wise Yarn", Value = "2" }
            };
            YarnStockReportVM model = new()
            {
                DDLReportType = ReportType
            };
            model.DateForm = DateTime.Now.ToString("dd-MMM-yyyy");
            model.DateTo = DateTime.Now.ToString("dd-MMM-yyyy");
            return View(model);
        }
        [HttpGet]
        public async Task<JsonResult> GetYarnStockSummaryWithRack(DateTime dateForm, DateTime dateTo, int withAllTransaction, int showEmptyClosing)
        {
            var data = await Mediator.Send(new YarnStockSummaryWithRackQuery { DateFrom = dateForm, DateTo = dateTo, WithAllTransaction = withAllTransaction, ShowEmptyClosing = showEmptyClosing });
            return Json(data);
        }

        public ActionResult CallViewComponents(AllStockReportVCQM vcqmModel)
        {
            var viewComponentName = "";
            if (vcqmModel.StockReprotName == "Yarn Summary")
            {
                viewComponentName = "YarnStockReport";
            }
            else if (vcqmModel.StockReprotName == "Rack Wise Yarn")
            {
                viewComponentName = "RackWiseYarnReport";
            }
            return ViewComponent(viewComponentName);
        }

        public async Task<IActionResult> RackWiseYarnReport(string LotNo = null, int BuildingID = 0, int FloorID = 0, int RackID = 0, int CompositionID = 0, string Count = null,int OrderBy=0)
        {
            var data = await Mediator.Send(new GetYarnRackBalanceReportQuery { LotNo = LotNo, BuildingID = BuildingID, FloorID = FloorID, RackID = RackID, CompositionID = CompositionID, Count = Count,OrderBy=OrderBy });

            return View(data);
        }
    }
}
