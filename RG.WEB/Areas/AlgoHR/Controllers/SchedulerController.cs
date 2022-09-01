using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.SchedulerTasks.Commands.Update;
using RG.WEB.Controllers;
using System.Threading.Tasks;

namespace RG.WEB.Areas.AlgoHR.Controllers
{
    [Area("AlgoHR")]
    [Route("AlgoHR/[controller]/[action]")]
    public class SchedulerController : BaseController
    {
        [HttpGet]
        [Authorize(Policy = "Permission_HR_Modify_Attendance")]
        public async Task<IActionResult> ModifyAttendance()
        {
            var result = await Mediator.Send(new ModifyAttendanceByShortLeaveAndOutsideDutyCommand { });            
            return Json(result);
        }
    }
}
