using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.Embro.CompanyInfos.Queries;
using RG.Application.ViewModel.MDSir.AccountsInfo;
using RG.WEB.Controllers;

namespace RG.WEB.Areas.MDSir.Controllers
{
    [Area("MDSir")]
    [Route("MDSir/[controller]/[action]")]
    [AllowAnonymous]
    public class AccountsInfoController : BaseController
    {
        private readonly IDropdownService _dropdownService;
        private readonly ICurrentUserService _currentUserService;

        public AccountsInfoController(IDropdownService dropdownService, ICurrentUserService currentUserService)
        {
            _dropdownService = dropdownService;
            _currentUserService = currentUserService;
        }
        public async Task<IActionResult> LoanDetails()
        {
            LoanDetailsVM model = new();

            model.DDLCompany = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery() { }),true);
            model.DDLMonths = _dropdownService.DDLMonth();
            model.DDLYears = _dropdownService.NumberDDL(DateTime.Now.Year - 5, DateTime.Now.Year, false, DateTime.Now.Year)
                .OrderByDescending(x => x.Value)
                .ToList();
            model.Month = DateTime.Now.Month;
            model.Year = DateTime.Now.Year;
            model.UserID = _currentUserService.UserID;

            return View(model);
        }
        //public async Task<IActionResult> LoanSummary()
        //{
        //    model.DDLCompany = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery() { }));
        //    model.DDLMonths = _dropdownService.NumberDDL(1, 12, false);
        //    model.DDLYears = _dropdownService.NumberDDL(DateTime.Now.Year - 10, DateTime.Now.Year, false, DateTime.Now.Year).OrderByDescending(x => x.Value).ToList();
        //    return View(model);
        //}
    }
}
