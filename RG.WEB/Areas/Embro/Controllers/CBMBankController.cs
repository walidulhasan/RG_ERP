using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.Embro.Setups.CBM_Banks.Queries;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.Embro.Controllers
{
    [Area("Embro")]
    [Route("Embro/[controller]/[action]")]
    public class CBMBankController : BaseController
    {
        private readonly IDropdownService _dropdownService;

        public CBMBankController(IDropdownService dropdownService)
        {
            _dropdownService = dropdownService;
        }
        public async Task<JsonResult> GetDDLBank(int companyID=0, string predict=null)
        {
            var data = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCBM_BankQuery { CompanyID=companyID, Predict = predict }), true);
            return Json(data);
        }
    }
}
