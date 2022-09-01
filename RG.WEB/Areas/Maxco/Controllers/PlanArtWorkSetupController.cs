using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.Maxco.Setup.Plan_ArtWork_Setup.Queries;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.Maxco.Controllers
{
    [Area("Maxco")]
    [Route("Maxco/[controller]/[action]")]
    public class PlanArtWorkSetupController : BaseController
    {
        private readonly IDropdownService _dropDownService;

        public PlanArtWorkSetupController(IDropdownService dropDownService)
        {
            _dropDownService = dropDownService;
        }
        public async Task<JsonResult> GetDDLArtWork()
        {
            return Json(_dropDownService.RenderDDL(await Mediator.Send(new GetDDLArtWorkQueries()), false));
        }
        public async Task<JsonResult> GetArtWorkByID(int ID)
        {
            return Json(await Mediator.Send(new GetPlanArtByIDQuery() { ArtID = ID }), false);
        }

    }
}
