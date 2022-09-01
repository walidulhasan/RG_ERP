using MediatR;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Setups.BuildingFloorInfos.Commands.Create;
using RG.Application.Contracts.MaterialsManagement.Setups.BuildingFloorInfos.Commands.DataTransferModel;
using RG.Application.Contracts.MaterialsManagement.Setups.BuildingFloorInfos.Commands.Update;
using RG.Application.Contracts.MaterialsManagement.Setups.BuildingFloorInfos.Queries;
using RG.Application.Contracts.MaterialsManagement.Setups.BuildingInfos.Queries;
using RG.Application.Contracts.MaterialsManagement.Setups.BuildingTypes.Queries;
using RG.Application.Contracts.MaterialsManagement.Setups.FloorTypes.Quries;
using RG.Application.Enums;
using RG.Application.ViewModel.MaterialsManagement.Setup;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.MaterialsManagement.Controllers
{
    [Area("MaterialsManagement")]
    [Route("MaterialsManagement/[controller]/[action]")]
    public class BuildingFloorInfoController : BaseController
    {
        private readonly IDropdownService _dropdownService;

        public BuildingFloorInfoController(IDropdownService dropdownService)
        {
            _dropdownService = dropdownService;
        }

        public async Task<JsonResult> GetDDLBuildingFloor(int Building, int FloorType, string Predict = null)
        {
            var data = _dropdownService.RenderDDL(await Mediator.Send(new DDLBuildingWiseBuildingFloorQuery { Building = Building, Floor = FloorType, Predict = Predict }), true);
            return Json(data);
        }

        public async Task<IActionResult> BuildingFloorInfoIndex()
        {
            var model = new BuildingFloorInfoVM
            {
                DDLBuildingType = _dropdownService.RenderDDL(await Mediator.Send(new DDLBuildingTypeQuery { }), true),
                DDLFloorType = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLFloorTypeQuery { }), true),
                DDLBuilding = _dropdownService.DefaultDDL(),
                DDLSerial = _dropdownService.NumberDDL(1, 50, true),
            };
            return View(model);
        }

        public async Task<JsonResult> DDLBuildingTypeWiseBuildingInfo(int ID, string Predict = null)
        {
            var data = _dropdownService.RenderDDL(await Mediator.Send(new DDLBuildingTypeWiseBuildingInfoQuery { id = ID, predict = Predict }), true);
            return Json(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetListOfBuildingFloorInfo(DataSourceLoadOptions loadOptions)
        {
            loadOptions.PrimaryKey = new[] { "BuildingFloorID" };
            loadOptions.PaginateViaPrimaryKey = true;
            var data = await Mediator.Send(new GetListOfBuildingFloorInfoQuery { LoadOptions = loadOptions });
            return Json(data);
        }

        [HttpPost]
        public async Task<IActionResult> BuildingFloorInfoCreate(BuildingFloorInfoDTM model)
        {
            RResult result = new();
            result = await Mediator.Send(new BuildingFloorInfoCreateCommand { Model = model });
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> BuildingFloorInfoUpdate(BuildingFloorInfoDTM modelUpdate)
        {
            RResult result = new();
            result = await Mediator.Send(new BuildingFloorInfoUpdateCommand { DtModelUpdate=modelUpdate });
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> BuildingFloorInfoRemove(int id)
        {
            RResult result = new();
            result = await Mediator.Send(new BuildingFloorInfoRemoveCommand { id=id });
            return Json(result);
        }

        


    }
}
