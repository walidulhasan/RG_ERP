using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.Maxco.Setup.Buyer_Setup.Queries;
using RG.Application.ViewModel.Maxco.Business.OrderReports;
using RG.WEB.Controllers;
using System.Threading.Tasks;

namespace RG.WEB.Areas.MDSir.Controllers
{
    [Area("MDSir")]
    [Route("MDSir/[controller]/[action]")]
    [AllowAnonymous]
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
            model.DDLBuyer = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLBuyerAllQuery()), true);
            model.DDLOrder = _dropdownService.DefaultDDL();
            return View(model);
        }
    }
}
