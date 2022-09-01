using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Setups.DailyProductionHour.Commands.Create;
using RG.Application.Contracts.MaterialsManagement.Setups.DailyProductionHour.Commands.DataTransferModel;
using RG.Application.Contracts.MaterialsManagement.Setups.DailyProductionHour.Commands.Update;
using RG.Application.Contracts.MaterialsManagement.Setups.DailyProductionHour.Queries;
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
    public class DailyProductionHourController : BaseController
    {
        public IActionResult Create()
        {
            DailyProductionHourDTM model = new DailyProductionHourDTM();

            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Create(DailyProductionHourDTM model)
        {
            RResult rResult = new RResult();
            if (ModelState.IsValid)
            {
                rResult = await Mediator.Send(new DailyProductionHourCreateCommand { DailyProductionHour = model });
            }
            return Json(rResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGridData(DataSourceLoadOptions loadOptions)
        {
            loadOptions.PrimaryKey = new[] { "ID" };
            loadOptions.PaginateViaPrimaryKey = true;
            var data = await Mediator.Send(new GetAllDailyProductionHourQuery { LoadOptions = loadOptions });
            return Json(data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(DailyProductionHourDTM model)
        {
            var resutl = await Mediator.Send(new DailyProductionHourUpdateCommand { DailyProductionHour = model });
            return Json(resutl);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var resutl = await Mediator.Send(new DailyProductionHourRemoveCommand { id = id });
            return Json(resutl);
        }

    }
}
