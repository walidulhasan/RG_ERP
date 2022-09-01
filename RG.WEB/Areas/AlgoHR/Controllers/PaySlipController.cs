using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.AlgoHR.Business.Tbl_Payroll_Masters.Query;
using RG.Application.Contracts.Embro.CompanyInfos.Queries;
using RG.Application.ViewModel.AlgoHR.Business.CompanyMonthlySalary;
using RG.Application.ViewModel.AlgoHR.Business.PaySlip;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.AlgoHR.Controllers
{
    [Area("AlgoHR")]
    [Route("AlgoHR/[controller]/[action]")]
    public class PaySlipController : BaseController
    {
        private readonly IDropdownService dropdownService;
        private readonly ICurrentUserService currentUserService;

        public PaySlipController(IDropdownService _dropdownService, ICurrentUserService _currentUserService)
        {
            dropdownService = _dropdownService;
            currentUserService = _currentUserService;
        }
        public IActionResult Salary()
        {
            var model = new SalaryVM()
            {
                EmployeeID = currentUserService.EmployeeID,
                EmployeeCode = currentUserService.EmployeeCode,
                Month = DateTime.Now.Month-1,
                DDLMonth = dropdownService.DDLMonth(DateTime.Now.Month, false),
                Year = DateTime.Now.Year,
                DDLYear = dropdownService.NumberDDL(DateTime.Now.Year - 2, DateTime.Now.Year, false, DateTime.Now.Year)
            };
            return View(model);
        }

        public async Task<JsonResult> GetSalaryPaySlipInfo(int employeeID,int month,int year)
        {
            var data = await Mediator.Send(new GetSalaryPaySlipInfoQuery {EmployeeID= employeeID, Month=month,Year=year });
            return Json(data);
        }
        [AllowAnonymous]
        public async Task<ActionResult> CompanyMonthlySalary()
        {
            var model = new CompanyMonthlySalaryVM
            {
                DDLMonth = dropdownService.DDLMonth(),
                DDLYear = dropdownService.NumberDDL(DateTime.Now.Year - 2, DateTime.Now.Year, false),
                DDLCompany = dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), true),
                Month = DateTime.Now.Month-1,
                Year = DateTime.Now.Year,
            };
            return View(model);
        }
    }
}
