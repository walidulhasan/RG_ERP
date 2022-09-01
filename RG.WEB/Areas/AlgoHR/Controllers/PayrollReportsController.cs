using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.ViewModel.AlgoHR.Business.PayrollReports;

namespace RG.WEB.Areas.AlgoHR.Controllers
{
    public class PayrollReportsController : Controller
    {
        private readonly IDropdownService _dropdownService;

        public PayrollReportsController(IDropdownService dropdownService)
        {
            _dropdownService = dropdownService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> MonthWiseGeneratePayroll()
        {
            MonthWiseGeneratePayrolVM model = new MonthWiseGeneratePayrolVM();
            model.DDLMonth = _dropdownService.DDLMonth(DateTime.Now.Month);
            model.DDLYear = _dropdownService.NumberDDL(DateTime.Now.Year-1,DateTime.Now.Year,null,false,DateTime.Now.Year);
            return View(model);
        }
    }
}
