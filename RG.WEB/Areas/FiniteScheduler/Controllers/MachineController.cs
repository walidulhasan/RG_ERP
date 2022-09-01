using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Constants;
using RG.Application.Contracts.Embro.CompanyInfos.Queries;
using RG.Application.Enums;
using RG.Application.ViewModel.FiniteScheduler.Setup.Machine;
using RG.WEB.Controllers;
using SSRSReport.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.FiniteScheduler.Controllers
{
    [Area("FiniteScheduler")]
    [Route("FiniteScheduler/[controller]/[action]")]
    public class MachineController : BaseController
    {
        private readonly IDropdownService dropdownService;

        public MachineController(IDropdownService _dropdownService)
        {
            dropdownService = _dropdownService;
        }
        public async Task<IActionResult> Index()
        {
            var model = new IndexVM()
            {
                DDLCompany = dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), true),
                DDLLocation = dropdownService.DefaultDDL()
            };
            return View(model);
        }
        public async Task<IActionResult> LocationWiseMachineReport(int companyID, int locationID, string ReportFormat)
        {
            var report = new CallSSRSReport();
            string reportName = $"/{ReportFolder.FiniteSchedulerFolder}/LocationWiseMachineList";

            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "CompanyID", companyID },
                { "LocationID", locationID }
            };

            var connectionString = (int)enum_ServerType.FiniteSchedulerConnection;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

        }
       
    }
}
