using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.Embro.CompanyInfos.Queries;
using RG.Application.Contracts.MaterialsManagement.Business.CMBL_PurchaseOrders.Queries;
using RG.Application.ViewModel.MDSir.CMBLPurchaseOrder;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.MDSir.Controllers
{
    [Area("MDSir")]
    [Route("MDSir/[controller]/[action]")]
    [AllowAnonymous]
    public class CMBLPurchaseOrderController : BaseController
    {
        private readonly IDropdownService _dropdownService;

        public CMBLPurchaseOrderController(IDropdownService dropdownService)
        {
            _dropdownService = dropdownService;
        }
        public async Task<IActionResult> POSearch()
        {
            var model = new POSearchVM()
            {
                DDLCompany = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), false),
                CompanyID = 20183,
                DDLPO= _dropdownService.DefaultDDL(),
            };
            return View(model);
        }
        public async Task<IActionResult> GetDDLPO(int companyID,string predict)
        {
            var data = await Mediator.Send(new GetDDLPOQuery { CompanyID = companyID, Predict = predict });
            return Json(data);
        }
        public async Task<IActionResult> POReport(long poid)
        {
            var data = await Mediator.Send(new GetPOReportMdSirQuery { POID = poid });
            return View(data);
        }

    }
}
