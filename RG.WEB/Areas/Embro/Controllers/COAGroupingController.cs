using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Common.Models;
using RG.Application.Contracts.Embro.Setups.BasicCOAs.Queries;
using RG.Application.Contracts.Embro.Setups.COAGroupCategorys.Queries;
using RG.Application.Contracts.Embro.Setups.COAGroupIdentifications.Commands.Create;
using RG.Application.Contracts.Embro.Setups.COAGroups.Commands.Create;
using RG.Application.Contracts.Embro.Setups.COAGroups.Commands.Update;
using RG.Application.Contracts.Embro.Setups.COAGroups.Querirs;
using RG.Application.ViewModel.Embro.Setup.COAGroupings;
using RG.DBEntities.Embro.Setup;
using RG.WEB.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RG.WEB.Areas.Embro.Controllers
{
    [Area("Embro")]
    [Route("Embro/[controller]/[action]")]
    public class COAGroupingController : BaseController
    {
        private readonly IDropdownService _dropdownService;

        public COAGroupingController(IDropdownService dropdownService)
        {
            _dropdownService = dropdownService;
        }
        public async Task<IActionResult> Create()
        {
            var model = new COAGroupingCreateVM
            {
                DDLGroupSerial = _dropdownService.NumberDDL(1, 50, true),
                DDLCOAGroupingCategory = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCOAGroupCategoryQuery { }), true)
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(COAGroupingCreateVM COAGrouping)
        {
            RResult result = new();
            if (ModelState.IsValid)
            {
                result = await Mediator.Send(new COAGroupingCreateCommand { COAGrouping = COAGrouping });
            }
            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetCOAGroupList(DataSourceLoadOptions loadOptions)
        {
            loadOptions.PrimaryKey = new[] { "GroupID" };
            loadOptions.PaginateViaPrimaryKey = true;
            var data = await Mediator.Send(new GetListOfCOAGroupQuery { LoadOptions = loadOptions });
            return Json(data);
        }

        
        public async Task<IActionResult> GroupIdentification()
        {
            var model = new GroupIdentificationVM();
            model.DDLCOAGroupingCategory = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCOAGroupCategoryQuery { }), true);
            model.DDLCOAGroup = _dropdownService.DefaultDDL();
            return View(model);
        }
        public async Task<JsonResult> GetDDLCOAGroup(int categoryID, string predict)
        {
            var data = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCOAGroupQuery { CategoryID = categoryID, Predict = predict }), true);
            return Json(data);
        }
        public async Task<JsonResult> GetBasicCOADetailInfo(int groupCategoryID, string predict)
        {
            var data = await Mediator.Send(new GetBasicCOADetailInfoQuery { GroupCategoryID = groupCategoryID, Predict = predict });
            return Json(data);
        }

        public async Task<IActionResult> Remove(int id)
        {
            RResult result = await Mediator.Send(new COAGroupingRemoveCommand { Id = id });
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> Update(COAGroupingCreateVM COAGrouping)
        {
            RResult result = new();
            if (ModelState.IsValid)
            {
                result = await Mediator.Send(new COAGroupingUpdateCommand { COAGrouping = COAGrouping });
            }
            return Json(result);
        }
        [HttpPost]
        public async Task<JsonResult> GroupIdentification(List<COAGroupIdentification> groupIdentifications)
        {
            var data = await Mediator.Send(new COAGroupIdentificationCreateCommand { GroupIdentification = groupIdentifications });
            return Json(data);
        }

    }
}
