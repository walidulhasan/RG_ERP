using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.MaterialsManagement.Setups.BuildingInfos.Queries;

using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.MaterialsManagement.Controllers
{
    [Area("MaterialsManagement")]
    [Route("MaterialsManagement/[controller]/[action]")]
    public class BuildingInfoController : BaseController
    {
        private readonly IDropdownService _dropdownService;

        public BuildingInfoController(IDropdownService dropdownService)
        {
            _dropdownService = dropdownService;
        }
        public async Task<JsonResult> GetDDLFloorTypeWiseBuilding(int FloorType, string Predict = null)
        {
            var data = _dropdownService.RenderDDL(await Mediator.Send(new DDLFloorTypeWiseBuildingQuery { FloorType = FloorType, Predict = Predict }), true);
            return Json(data);
        }

       
    }
}
