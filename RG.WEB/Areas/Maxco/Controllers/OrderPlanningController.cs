using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.Maxco.Buisness.Plan_OrderMasters.Commands.Create;
using RG.Application.Contracts.Maxco.Buisness.Plan_OrderMasters.Queries;
using RG.Application.Contracts.Maxco.Buisness.Style.Queries;
using RG.Application.ViewModel.Maxco.Business.OrderPlanning;
using RG.DBEntities.Maxco.Business;
using RG.WEB.Controllers;
using System.Threading.Tasks;

namespace RG.WEB.Areas.Maxco.Controllers
{
    [Area("Maxco")]
    [Route("Maxco/[controller]/[action]")]
    public class OrderPlanningController : BaseController
    {
        private readonly IDropdownService dropDownService;

        public OrderPlanningController(IDropdownService _dropDownService)
        {
            dropDownService = _dropDownService;
        }
        public async Task<IActionResult> Create(string predict)
        {
            var model = new OrderPlanningCrateVM()
            {
                DDLOrders = dropDownService.RenderDDL(await Mediator.Send(new GetDDLOrdersQuery { Predict = predict }))
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Plan_OrderMaster orderPlanMaster)
        {
            var data = await Mediator.Send(new PlanOrderMasterCreateCommand { PlanOrderMaster = orderPlanMaster });
            return Json(data);

        }
        public async Task<JsonResult> GetOrderWisePlanVersions(int orderID)
        {
            var data = await Mediator.Send(new GetOrderWisePlanVersionsQuery { OrderID = orderID });
            return Json(data);
        }
        public async Task<JsonResult> GetPlanOrderDetailInfo(int orderID)
        {
            var data = await Mediator.Send(new GetPlanOrderDetailInfoQuery { OrderID = orderID });
            return Json(data);
        }
        public async Task<JsonResult> GetOrderPlanningVersionDetail(int orderID, int planVersionID)
        {
            var data = await Mediator.Send(new GetOrderPlanningVersionDetailQuery { OrderID = orderID, PlanVersionID = planVersionID });
            var a = Json(data);
            return a;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isOrderClosed">
        /// null gives all planned orders
        /// true gives only followup closed orders
        /// false gives only followup not closed orders
        /// </param>
        /// <param name="predict"></param>
        /// <returns></returns>
        public async Task<JsonResult> GetDDLPlanOrders(bool? isOrderClosed, string predict)
        {
            var data = await Mediator.Send(new GetDDLPlanOrdersQuery { IsOrderClosed = isOrderClosed, Predict = predict });
            return Json(data);
        }
    }
}
