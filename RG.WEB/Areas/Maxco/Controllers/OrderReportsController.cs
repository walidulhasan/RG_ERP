using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.Maxco.Buisness.OrderReports.Queries;
using RG.Application.Contracts.Maxco.Setup.Buyer_Setup.Queries;
using RG.Application.ViewModel.Maxco.Business.OrderReports;
using RG.WEB.Controllers;
using System;
using System.Threading.Tasks;

namespace RG.WEB.Areas.Maxco.Controllers
{
    [Area("Maxco")]
    [Route("Maxco/[controller]/[action]")]
    public class OrderReportsController : BaseController
    {
        private readonly IDropdownService _dropdownService;

        public OrderReportsController(IDropdownService dropdownService)
        {
            _dropdownService = dropdownService;
        }
        public async Task<IActionResult> OrderShipmentBalance()
        {
            OrderShipmentBalanceVM model = new();
            model.DDLBuyer = _dropdownService.RenderDDL( await Mediator.Send(new GetDDLBuyerAllQuery()),true);
            model.DDLOrder = _dropdownService.DefaultDDL();
            return View(model);
        }
        [AllowAnonymous]
        public async Task<IActionResult> OrderShipmentBalanceReport(int buyerID, int orderID, DateTime dateFrom, DateTime dateTo)
        {
            var dateFromStr = dateFrom.ToString("dd-MMM-yyyy");
            var dateToStr = dateTo.ToString("dd-MMM-yyyy");

            var data = await Mediator.Send(new GetOrderShipmentBalanceReportQuery { BuyerID = buyerID, OrderID = orderID, DateFrom = dateFrom, DateTo = dateTo });
            data.ForEach(x => { x.DateFrom = dateFromStr; x.DateTo = dateToStr; });
            
            return View(data);
        }
        [AllowAnonymous]
        public async Task<IActionResult> ShipmentOrderInfo(int OrderID)
        {
            var data = await Mediator.Send(new GetShipmentOrderInfoQuery { OrderID = OrderID });
            return Json(data);


        }

    }
}
