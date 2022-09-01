using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.Maxco.Buisness.Plan_OrderFlowups.Queries;
using RG.Application.Contracts.Maxco.Buisness.Plan_OrderFollowups.Commands.Create;
using RG.Application.Contracts.Maxco.Buisness.Plan_OrderFollowups.Commands.DataTransferModel;
using RG.Application.Contracts.Maxco.Buisness.Plan_OrderMasters.Queries;
using RG.Application.Contracts.Maxco.Setup.OrderClassifications.Queries;
using RG.Application.ViewModel.Maxco.Business.OrderPlanFollowup;
using RG.WEB.Controllers;
using System.Threading.Tasks;

namespace RG.WEB.Areas.Maxco.Controllers
{
    [Area("Maxco")]
    [Route("Maxco/[controller]/[action]")]
    public class OrderPlanFollowupController : BaseController
    {
        private readonly IDropdownService dropDownService;

        public OrderPlanFollowupController(IDropdownService _dropDownService)
        {
            dropDownService = _dropDownService;
        }
        public async Task<IActionResult> Create()
        {
            var model = new OrderPlanFollowupCreateVM()
            {
                DDLOrder = dropDownService.RenderDDL(await Mediator.Send(new GetDDLPlanOrdersQuery() { IsOrderClosed = null, Predict = null }), true),
                DDLOrderClassification = await Mediator.Send(new GetDDLOrderClassificationQuery { }),
                DDLYesNo = dropDownService.BoleanYesOrNoDDL(),
                IsOrderClosed = "false",
            };
            return View(model);
        }
        [HttpPost]
        public async Task<JsonResult> Create(Plan_OrderFollowupDTM followup)
        {
            var data = await Mediator.Send(new CreatePlanOrderFollowupCommand { Followup = followup });
            return Json(data);
        }
        public async Task<JsonResult> GetOrderPlanFollowup(int orderID)
        {
            var data = await Mediator.Send(new GetOrderPlanFollowupQuery { OrderID = orderID });
            return Json(data);
        }

    }
}
