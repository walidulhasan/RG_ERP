using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.MaterialsManagement.Business.Yarn_AllocationToKnitters.Queries;
using RG.Application.Contracts.MaterialsManagement.Business.Yarn_IssuanceToKnitterMasters.Commands.Create;
using RG.Application.Contracts.MaterialsManagement.Business.YarnIssuanceToKnitter.Commands.DataTransferModel;
using RG.Application.ViewModel.MaterialsManagement.Business.YarnIssuanceToKnitter;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.MaterialsManagement.Controllers
{
    [Area("MaterialsManagement")]
    [Route("MaterialsManagement/[controller]/[action]")]
    public class YarnIssuanceToKnitterController : BaseController
    {
        private readonly IDropdownService _dropdownService;

        public YarnIssuanceToKnitterController(IDropdownService dropdownService)
        {
            _dropdownService = dropdownService;
        }
        public IActionResult Issue()
        {
            var model = new IssueVM();
            model.DDLOrder = _dropdownService.DefaultDDL();
            model.DDLKRS = _dropdownService.DefaultDDL();
            model.DDLYKNC = _dropdownService.DefaultDDL();
            return View(model);
        }
        [HttpPost]
        public async Task<JsonResult> Issue(AllocatedYarnIssueDTM allocatedYarnIssue)
        {
            //var data = await Mediator.Send(new Yarn_IssuanceToKnitterMasterCreateCommand {AllocatedYarnIssue=allocatedYarnIssue });
            return Json(1);
        }
        public async Task<JsonResult> GetDDL_Order_WaitingForYarnIssue(string predict)
        {
            DateTime dateFrom = DateTime.Now.AddMonths(-12);
            DateTime dateTo = DateTime.Now;

            var data = await Mediator.Send(new GetDDL_Order_WaitingForYarnIssueQuery { DateFrom = dateFrom, DateTo = dateTo, Predict = predict });
            return Json(data);
        }        
        public async Task<JsonResult> GetDDL_KRS_WaitingForYarnIssue(int orderID,string predict)
        {
            DateTime dateFrom = DateTime.Now.AddMonths(-12);
            DateTime dateTo = DateTime.Now;

            var data = await Mediator.Send(new GetDDL_KRS_WaitingForYarnIssueQuery { DateFrom = dateFrom, DateTo = dateTo,OrderID=orderID, Predict = predict });
            return Json(data);
        }
        public async Task<JsonResult> GetDDL_YKNC_WaitingForYarnIssue(int orderID,int krsID,string predict)
        {
            DateTime dateFrom = DateTime.Now.AddMonths(-12);
            DateTime dateTo = DateTime.Now;

            var data = await Mediator.Send(new GetDDL_YKNC_WaitingForYarnIssueQuery { DateFrom = dateFrom, DateTo = dateTo,OrderID=orderID,KRSID=krsID, Predict = predict });
            return Json(data);
        }

        public async Task<JsonResult> GetYarnLotForIssuance(long ykncID)
        {
            var data = await Mediator.Send(new GetYarnLotForIssuanceQuery { YKNCID = ykncID });
            return Json(data);
        }
    }
}
