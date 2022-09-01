using Microsoft.AspNetCore.Mvc;
using RG.Application.Contracts.AlgoHR.Business.EmployeeShortLeaves.Commands.Create;
using RG.Application.ViewModel.AlgoHR.Business.EmployeeShortLeave;
using RG.WEB.Controllers;
using System.Threading.Tasks;

namespace RG.WEB.Areas.AlgoHR.Controllers
{
    [Area("AlgoHR")]
    [Route("AlgoHR/[controller]/[action]")]
    public class EmployeeShortLeaveController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(ShortLeaveCreateVM empLeave)
        {
            var result = await Mediator.Send(new EmployeeShortLeaveCreateCommand { ShortLeave = empLeave });
            return Json(result);
        }
    }
}
