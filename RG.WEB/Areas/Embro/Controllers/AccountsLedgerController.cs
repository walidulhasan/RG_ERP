using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.Embro.CompanyInfos.Queries;
using RG.Application.ViewModel.Embro.Business.AccountsLedgers;
using RG.Infrastructure.ImplementInterfaces.CommonServices;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.Embro.Controllers
{
    [Area("Embro")]
    [Route("Embro/[controller]/[action]")]
    public class AccountsLedgerController : BaseController
    {
        private readonly IDropdownService _dropdownService;

        public AccountsLedgerController(IDropdownService dropdownService)
        {
            _dropdownService = dropdownService;
        }
        public async Task<IActionResult>  LedgerReport()
        {
            var model = new LedgerReportVM();
            var dateTime = DateTime.Now;
            model.DDLCompany = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), false);
            model.StartDate = dateTime.ToString("dd-MMM-yyyy");
            model.EndtDate = dateTime.ToString("dd-MMM-yyyy");
            return View(model);
        }
    }
}
