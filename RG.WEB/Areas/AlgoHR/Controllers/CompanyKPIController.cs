using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.AlgoHR.Business.KPIParticularValuess.Commands.Create;
using RG.Application.Contracts.AlgoHR.Business.KPIParticularValuess.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Setups.CompanyKPIParticularss.Queries;
using RG.Application.Contracts.AlgoHR.Setups.CompanyKPIParticularss.Queries.RequestResponseModel;
using RG.Application.ViewModel.AlgoHR.Business.CompanyKPI;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.AlgoHR.Controllers
{
    [Area("AlgoHR")]
    [Route("AlgoHR/[controller]/[action]")]
    public class CompanyKPIController : BaseController
    {
        private readonly IDropdownService _dropdownService;

        public CompanyKPIController(IDropdownService dropdownService)
        {
            _dropdownService = dropdownService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            CompanyKPICreateVM model = new()
            {
                DDLYear = _dropdownService.NumberDDL(DateTime.Now.AddYears(-1).Year, DateTime.Now.Year, true),
                KPIYear = DateTime.Now.Year,
                DDLMonth = _dropdownService.DDLMonth(DateTime.Now.Month),
                KPIMonth = DateTime.Now.Month
            };
            return View(model);
        }
        [HttpPost]
        public async Task<JsonResult> Create(List<CompanyKPICreateDTM> particularList)
        {
            var result = await Mediator.Send(new KPIParticularValuesCreateCommand { KPIData = particularList });
            return Json(result);
        }

        public IActionResult Report()
        {
            CompanyKPIReportVM model = new()
            {
                DDLYear = _dropdownService.NumberDDL(DateTime.Now.AddYears(-1).Year, DateTime.Now.Year, true),
                KPIYear = DateTime.Now.Year,
                DDLMonth = _dropdownService.DDLMonth(DateTime.Now.Month),
                KPIMonth = DateTime.Now.Month
            };
            return View(model);
        }
        public async Task<IActionResult> KPIReport(int month,int year,int forLastYears)
        {
            var data = await Mediator.Send(new GetAllCompanyKPIParticularsReportQuery { KPIMonth = month, KPIYear = year, ForLastYears = forLastYears }); 
            return View(data);
        }
        public async Task<JsonResult> GetAllCompanyKPIParticulars(int month, int year)
        {
            var data = await Mediator.Send(new GetAllCompanyKPIParticularsQuery { KPIMonth = month, KPIYear = year });
            return Json(data);
        }
        public async Task<JsonResult> GetAllCompanyKPIParticularsReport(int month, int year)
        {
            var data = await Mediator.Send(new GetAllCompanyKPIParticularsReportQuery { KPIMonth = month, KPIYear = year ,ForLastYears=0});
            return Json(data);
        }

        
    }
}
