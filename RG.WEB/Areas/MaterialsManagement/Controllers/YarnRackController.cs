using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Setups.BuildingInfos.Queries;
using RG.Application.Contracts.MaterialsManagement.Setups.BuildingInfos.Queries.RequestResponseModel;
using RG.Application.Contracts.MaterialsManagement.Setups.YarnRackSetups.Commands.Create;
using RG.Application.Contracts.MaterialsManagement.Setups.YarnRackSetups.Commands.Update;
using RG.Application.Contracts.MaterialsManagement.Setups.YarnRackSetups.Queries;
using RG.Application.Enums;
using RG.Application.ViewModel.MaterialsManagement.Setup;
using RG.WEB.Controllers;
using System.Threading.Tasks;

namespace RG.WEB.Areas.MaterialsManagement.Controllers
{
    [Area("MaterialsManagement")]
    [Route("MaterialsManagement/[controller]/[action]")]
    public class YarnRackController : BaseController
    {
        private readonly IDropdownService _dropdownService;
        private readonly ICurrentUserService _currentUserService;

        public YarnRackController(IDropdownService dropdownService, ICurrentUserService currentUserService)
        {
            _dropdownService = dropdownService;
            _currentUserService = currentUserService;
        }
        public async Task<IActionResult> Index()
        {
            YarnRackCreateVM model = new()
            {
                DDLRackNumber = _dropdownService.NumberDDL(1, 100, true),
                DDLBuilding = _dropdownService.RenderDDL(await Mediator.Send(new DDLFloorTypeWiseBuildingQuery { FloorType = (int)enum_FloorType.YarnStore }), true),
                DDLLBuildingFloor = _dropdownService.DefaultDDL()
            };
            return View(model);
        }
        public async Task<IActionResult> Create()
        {
            YarnRackCreateVM model = new()
            {
                DDLRackNumber = _dropdownService.NumberDDL(1, 100, true),
                DDLBuilding = _dropdownService.RenderDDL(await Mediator.Send(new DDLFloorTypeWiseBuildingQuery { FloorType = (int)enum_FloorType.YarnStore }), true),
                DDLLBuildingFloor = _dropdownService.DefaultDDL(),

            };
            //model.YarnSubRackSetup.ForEach(b => { b.StorageLimit = 5000; });
            return View(model);
        }

        [HttpPost]
        public async Task<JsonResult> Create(YarnRackCreateVM yarnRackCreateVM)
        {
            RResult rResult = new RResult();
            rResult = await Mediator.Send(new YarnRackCreateCommand { yarnRackCreateVM = yarnRackCreateVM });
            return Json(rResult);
        }
        public async Task<JsonResult> GetDDLBuildingFloorWiseRack(int buildingFloorID)
        {
            var data = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLBuildingFloorWiseRackQuery { BuildingFloorID = buildingFloorID }),true);
            return Json(data);
        }
        [HttpGet]
        public async Task<JsonResult>GetFloorWiseRackInfo(int buildingFloorID)
        {
            var data = await Mediator.Send(new GetFloorWiseRackInfoQuery { BuildingFloorID = buildingFloorID });
            return Json(data);
        }
        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            RResult result = await Mediator.Send(new RackRemoveCommand { RackId = id });
            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetDDLLotNoWithRackWiseLotno(int rackID,string predict=null)
        {
            var data=_dropdownService.RenderDDL( await Mediator.Send(new DDLLotNowithRackWiseLotnoQuery { RackID = rackID ,Predict=predict}),true);
            return Json(data);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int rackID)
        {
            YarnRackCreateVM model = new();

            if (rackID > 0)
            {
               
                model = await Mediator.Send(new RackDataToUpdateGetQuery { rackID = rackID });
                model.DDLBuilding = _dropdownService.RenderDDL(await Mediator.Send(new DDLFloorTypeWiseBuildingQuery { FloorType = (int)enum_FloorType.YarnStore }), true);
                model.Building = (await Mediator.Send(new BuildingFloorWiseBuildingInfoQuery {BuildingfloorID= model.BuildingFloorID })).BuildingID;
                model.DDLRackNumber = _dropdownService.NumberDDL(1, 100, true);

            }
            return View("Create", model);
        }

        [HttpPost]
        public async Task<JsonResult> Update(YarnRackCreateVM rackUpdate)
        {
            var result = await Mediator.Send(new RackAllDetailsUpdateCommand { yarnRackCreateVM = rackUpdate });
            return Json(result);
        }
    }
}
