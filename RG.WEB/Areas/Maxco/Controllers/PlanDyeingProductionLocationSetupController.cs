using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.Maxco.Setup.Plan_DyeingProductionLocation_Setup.Queries;
using RG.WEB.Controllers;
using System.Threading.Tasks;

namespace RG.WEB.Areas.Maxco.Controllers
{
    [Area("Maxco")]
    [Route("Maxco/[controller]/[action]")]
    public class PlanDyeingProductionLocationSetupController : BaseController
    {
        private readonly IDropdownService _dropDownService;

        public PlanDyeingProductionLocationSetupController(IDropdownService dropDownService)
        {
            _dropDownService = dropDownService;
        }
        public async Task<JsonResult> GetDDLPlanDyeingProductionLocation()
        {
            return Json(_dropDownService.RenderDDL(await Mediator.Send(new GetDDLDyeingProductionLocationQuery()), false));
        }
        public async Task<JsonResult> GetDyeingProductionLocationByID(int ID)
        {
            return Json(await Mediator.Send(new GetDyeingProductionLocationByIDQuery() {ProductionLocationID=ID }));
        }
    }
}
