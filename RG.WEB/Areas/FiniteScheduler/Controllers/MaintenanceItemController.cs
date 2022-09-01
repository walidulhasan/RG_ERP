using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MachineMaintenanceCategory_Setups.Queries;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceItem_Setups.Commands.Create;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceItem_Setups.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceItem_Setups.Commands.Update;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceItem_Setups.Queries;
using RG.Application.ViewModel.FiniteScheduler.Setup.MaintenanceItem;
using RG.WEB.Controllers;
using System.Threading.Tasks;

namespace RG.WEB.Areas.FiniteScheduler.Controllers
{
    [Area("FiniteScheduler")]
    [Route("FiniteScheduler/[controller]/[action]")]
    public class MaintenanceItemController : BaseController
    {
        private readonly IDropdownService dropdownService;

        public MaintenanceItemController(IDropdownService _dropdownService)
        {
            dropdownService = _dropdownService;
        }
        public async Task<IActionResult> Create()
        {
            var model = new MT_MaintenanceItem_SetupVM();
            model.DDLItemCategory = dropdownService.RenderDDL(await Mediator.Send(new DDLGetMachineMaintenanceCategoryListQuery()));
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(MT_MaintenanceItem_SetupDTM dtm)
        {
            var rResult = new RResult();
            if (ModelState.IsValid)
            {
                rResult = await Mediator.Send(new MT_MaintenanceItem_SetupCreateCommand { MT_MaintenanceItem_Setup = dtm, SaveChange = true });

            }
            return Json(rResult);

        }

        [HttpPut]
        public async Task<IActionResult> Update(MT_MaintenanceItem_SetupDTM dtm)
        {
            var rResult = new RResult();
            if (ModelState.IsValid)
            {
                rResult = await Mediator.Send(new MT_MaintenanceItem_SetupUpdateCommand { MT_MaintenanceItem_Setup = dtm, SaveChange = true });

            }
            return Json(rResult);

        }
        [HttpPut]
        public async Task<IActionResult> Remove(int itemID)
        {
            var rResult = new RResult();
            if (ModelState.IsValid)
            {
                rResult = await Mediator.Send(new MT_MaintenanceItem_SetupRemoveCommand { ItemID = itemID });

            }
            return Json(rResult);

        }
        [HttpGet]
        public async Task<IActionResult> GetListOFMaintenanceItem(DataSourceLoadOptions loadOptions, int itemCategoryID)
        {
            loadOptions.PrimaryKey = new[] {"ID"};
            loadOptions.PaginateViaPrimaryKey = true;
            var data = await Mediator.Send(new GetListOFMaintenanceItemQuery { ItemCategoryID = itemCategoryID, LoadOptions = loadOptions });
            return Json(data);
        }

    }
}
