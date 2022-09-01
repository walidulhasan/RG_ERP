using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.Embro.CompanyInfos.Queries;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_Location_Setups.Queries;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_Machine_Setups.Queries;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceSchedule_Setups.Queries;
using RG.WEB.Controllers;
using System.Threading.Tasks;

namespace RG.WEB.Areas.FiniteScheduler.Controllers
{
    [Area("FiniteScheduler")]
    [Route("FiniteScheduler/[controller]/[action]")]
    public class CommonDropDownController : BaseController
    {
        private readonly IDropdownService dropdownService;
        public CommonDropDownController(IDropdownService _dropdownService)
        {
            dropdownService = _dropdownService;
        }
        #region Json Functions
       
        public async Task<JsonResult> GetDDLCompanyWiseLocation(int companyID)
        {
            var data = dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyWiseLocationQuery { CompanyID = companyID }), true);
            return Json(data);
        }
        public async Task<JsonResult> GetDDLLocationWiseMachine(int locationID)
        {
            var data = dropdownService.RenderDDL(await Mediator.Send(new GetDDLLocationWiseMachineQuery { LocationID = locationID }), true);
            return Json(data);
        }
        public async Task<JsonResult> GetDDLMachineWiseMaintenanceSchedule(int machineID)
        {
            var data = dropdownService.RenderDDL(await Mediator.Send(new GetDDLMachineWiseMaintenanceScheduleQuery { MachineID = machineID }), false);
            return Json(data);
        }
        

        #endregion
    }
}
