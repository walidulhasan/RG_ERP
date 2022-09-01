using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Buisness.OrderCuttingSchedulings.Commands.Update;
using RG.Application.Contracts.Maxco.Buisness.OrderCuttingSchedulings.Queries;
using RG.Application.Contracts.Maxco.Buisness.OrderDyeingSchedulings.Commands.Update;
using RG.Application.Contracts.Maxco.Buisness.OrderDyeingSchedulings.Queries;
using RG.Application.Contracts.Maxco.Buisness.OrderSchedulingMasters.Commands.Create;
using RG.Application.Contracts.Maxco.Buisness.OrderSchedulingMasters.Commands.DataTransferModel;
using RG.Application.Contracts.Maxco.Buisness.OrderSchedulingMasters.Queries;
using RG.Application.Contracts.Maxco.Buisness.OrderSewingSchedulings.Commands.Update;
using RG.Application.Contracts.Maxco.Buisness.OrderSewingSchedulings.Queries;
using RG.Application.Contracts.Maxco.Buisness.Style.Queries;
using RG.Application.Contracts.Maxco.OrderKnittingSchedulings.Commands.Update;
using RG.Application.Contracts.Maxco.OrderKnittingSchedulings.Queries;
using RG.Application.ViewModel.Maxco.Business.OrderScheduling;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.Maxco.Controllers
{
    [Area("Maxco")]
    [Route("Maxco/[controller]/[action]")]
    public class OrderSchedulingController : BaseController
    {
        private readonly IDropdownService _dropDownService;

        public OrderSchedulingController(IDropdownService dropDownService)
        {
            _dropDownService = dropDownService;
        }
        public async Task<IActionResult> OrderSchedulingCreate(string predict)
        {
            var model = new OrderSchedulingMasterVM()
            {
                DDLOrders = _dropDownService.RenderDDL(await Mediator.Send(new GetDDLOrdersQuery { Predict = predict })),
                ScheduleDate = DateTime.Now.ToString("dd-MMM-yyyy"),
            };

            return View(model);
        }

        public async Task<JsonResult> GetOrderSchedulingInfo(int orderID)
        {
            var data = await Mediator.Send(new GetOrderSchedulingInfoQuery { id = orderID });
            return Json(data);
        }
        [HttpPost]
        public async Task<JsonResult> OrderSchedulingCreate(OrderSchedulingMastersDTM OrderSchedulingMasters)
        {
            RResult rResult = new();
            rResult = await Mediator.Send(new OrderSchedulingCreateMasterCommand { OrderSchedulingMasters= OrderSchedulingMasters });
            return Json(rResult);
        }

        [HttpGet]
        public async Task<JsonResult> GetListOrderKnittingScheduling(int fabid,int krsid)
        {
            var data = await Mediator.Send(new GetListOrderKnittingSchedulingQuery {krsid=krsid,fabid=fabid });
            return Json(data);
        }
        [HttpPost]
        public async Task<JsonResult> DeleteOrderKnittingScheduling(int id)
        {
            var data = await Mediator.Send(new DeleteOrderKnittingSchedulingCommand { id=id});
            return Json(data);
        }
        [HttpPost]
        public async Task<JsonResult> GetListDyeingFinishFabric(int OrderId, int GSM, int FabricQualityID, string FabricComposition, string PantoneNo, decimal FinishedWidth)
        {
            var data = await Mediator.Send(new GetListDyeingFinishFabricQuery { OrderID= OrderId,GSM=GSM,FabricQualityID=FabricQualityID,FabricComposition=FabricComposition,PantoneNo=PantoneNo,FinishedWidth=FinishedWidth });
            return Json(data);
        }
        [HttpPost]
        public async Task<JsonResult> DeleteDyeingFinishFabric(int id)
        {
            var data = await Mediator.Send(new DeleteDyeingFinishFabricCommand { DyeingId = id });
            return Json(data);
        }

        [HttpPost]
        public async Task<JsonResult> GetListOrderCuttingScheduling(int OrderId, int GSM, int FabricQualityID, string FabricComposition, string PantoneNo, decimal FinishedWidth)
        {
            var data = await Mediator.Send(new GetListOrderCuttingSchedulingQuery { OrderId = OrderId, GSM = GSM, FabricQualityID = FabricQualityID, FabricComposition = FabricComposition, PantoneNo = PantoneNo, FinishedWidth = FinishedWidth });
            return Json(data);
        }
        [HttpPost]
        public async Task<JsonResult> DeleteCuttingScheduling(int id)
        {
            var data = await Mediator.Send(new DeleteCuttingSchedulingCommand { id = id });
            return Json(data);
        }
        [HttpPost]
        public async Task<JsonResult> DeleteSewingScheduling(int id)
        {
            var data = await Mediator.Send(new DeleteSewingSchedulingCommand { id = id });
            return Json(data);
        }
        
        [HttpGet]
        public async Task<JsonResult> GetListSewingScheduling(int OrderId, int GSM, int FabricQualityID, string FabricComposition, string PantoneNo, decimal FinishedWidth)
        {
            var data = await Mediator.Send(new GetListSewingSchedulingQuery { OrderId = OrderId, GSM = GSM, FabricQualityID = FabricQualityID, FabricComposition = FabricComposition, PantoneNo = PantoneNo, FinishedWidth = FinishedWidth });
            return Json(data);
        }


    }
}
