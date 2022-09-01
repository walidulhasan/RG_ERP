using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.AlgoHR.Business.CompanyMonthlySalarys.Queries;
using RG.Application.Contracts.AlgoHR.Business.MonthlyProductionCostAnalysiss.Query;
using RG.Application.Contracts.AlgoHR.Business.SalaryAnalysisDivisions.Query;
using RG.Application.ViewModel.MDSir.Salary;
using RG.DBEntities.AlgoHR.Business;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.MDSir.Controllers
{
    [Area("MDSir")]
    [Route("MDSir/[controller]/[action]")]
    [AllowAnonymous]
    public class SalaryController : BaseController
    {
        private readonly IDropdownService _dropdownService;

        public SalaryController(IDropdownService dropdownService)
        {
            _dropdownService = dropdownService;
        }
        public async Task<ActionResult> CompanyMonthlySalary(int CompanyId, int Month, int Year)
        {

            var data = await Mediator.Send(new GetCompanyMonthlySalaryQuery { CompanyId = CompanyId, Month = Month, Year = Year });
            ViewBag.companyID = CompanyId;
            return View(data);
        }
        public async Task<ActionResult> CompanyDivisionMonthlySalary(int CompanyId, int DivisionID, int Month, int Year)
        {

            var data = await Mediator.Send(new GetCompanyDivisionMonthlySalaryQuery { CompanyId = CompanyId, DivisionId = DivisionID, Month = Month, Year = Year });
            ViewBag.companyID = CompanyId;
            return View(data);
        }

        public IActionResult SalaryAnalysis()
        {
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            if (month == 1)
            {
                month = 12;
                year = year - 1;
            }
            else
            {
                month = month - 1;
            }
            var model = new SalaryAnalysisVM
            {
                Month = month,
                Year = year,
                DDLMonth = _dropdownService.DDLMonth(),
                DDLYear = _dropdownService.NumberDDL(DateTime.Now.Year - 2, DateTime.Now.Year, false)
            };
            return View(model);

        }
        public async Task<IActionResult> SalaryAnalysisReport(int Month, int Year)
        {
            var data = await Mediator.Send(new GetMonthlyProductionCostAnalysisQuery { Month = Month, Year = Year });
            return View(data);
        }
        public async Task<IActionResult> SalaryAnalysisDetailReport(int SalaryAnalysisDivisionID, int Month, int Year)
        {          
            
            var data = await Mediator.Send(new GetSalaryAnalysisDetailReportQuery {SalaryAnalysisDivisionID= SalaryAnalysisDivisionID, Month = Month, Year = Year });
            
            return View(data);
        }
        public async Task<IActionResult> CostHeadWiseAllowance(string analysisDivision, string departmentGroup, int month, int year)
        {
            var data = await Mediator.Send(new GetAnalysisDivisionWiseSalaryQuery { AnalysisDivision = analysisDivision, DepartmentGroup = departmentGroup, Year = year, Month = month });
            return View(data);
        }
        

        public async Task<IActionResult> DivisionWiseSalary(string analysisDivision , string departmentGroup, int month, int year)
        {
            var data = await Mediator.Send(new GetAnalysisDivisionWiseSalaryQuery {AnalysisDivision=analysisDivision, DepartmentGroup = departmentGroup, Year = year, Month = month });
            return View(data);
        }
        public async Task<IActionResult> DivisionWiseAllowance (string analysisDivision, string departmentGroup, int month, int year)
        {
            var data = await Mediator.Send(new GetAnalysisDivisionWiseAllowanceQuery { AnalysisDivision = analysisDivision, DepartmentGroup = departmentGroup, Year = year, Month = month });
            return View(data);
        }

    }
}
