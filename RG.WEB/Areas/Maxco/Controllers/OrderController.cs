using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.Maxco.Buisness.Style.Queries;
using RG.WEB.Controllers;
using System;
using System.Threading.Tasks;

namespace RG.WEB.Areas.Maxco.Controllers
{
    [Area("Maxco")]
    [Route("Maxco/[controller]/[action]")]
    public class OrderController : BaseController
    {
        private readonly IDropdownService _dropDownService;
        public OrderController(IDropdownService dropdownService)
        {
            _dropDownService = dropdownService;
        }

        public async Task<JsonResult> GetOrder(int BuyerID = 0, DateTime? ConditionDate = null, string Predict = null)
        {
            if (ConditionDate == null)
            {
                ConditionDate = DateTime.Now.AddYears(-2);
            }
            var data = _dropDownService.RenderDDL(await Mediator.Send(new GetDDLOrdersQuery { FromDate = ConditionDate, BuyerID = BuyerID, Predict = Predict }),true);
            return Json(data);
        }
        [AllowAnonymous]
        public async Task<JsonResult> GetOrderWithOutSample(int BuyerID = 0, DateTime? ConditionDate = null, string Predict = null)
        {
            if (ConditionDate == null)
            {
                ConditionDate = DateTime.Now.AddYears(-2);
            }
            var data = _dropDownService.RenderDDL(await Mediator.Send(new GetDDLOrdersWithOutSampleQuery { FromDate = ConditionDate, BuyerID = BuyerID, Predict = Predict }), true);
            return Json(data);
        }
    }
}
