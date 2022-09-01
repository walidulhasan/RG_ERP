using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Common.Models;
using RG.Application.Contracts.Embro.CompanyInfos.Queries;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_Machine_Setups.Commands.Create;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_Machine_Setups.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_Machine_Setups.Commands.Update;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_Machine_Setups.Queries;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MachineGroup.Queries;
using RG.Application.ViewModel.FiniteScheduler.Setup.MTMachineSetup;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.FiniteScheduler.Controllers
{
    [Area("FiniteScheduler")]
    [Route("FiniteScheduler/[controller]/[action]")]
    public class MTMachineSetupController : BaseController
    {
        private readonly IDropdownService dropdownService;

        public MTMachineSetupController(IDropdownService _dropdownService)
        {
            dropdownService = _dropdownService;
        }
        public async Task<IActionResult> Create()
        {
            var model = new MT_Machine_SetupVM
            {
                DDLCompany = dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), true),
                DDLLocation = dropdownService.DefaultDDL(),
                DDLMachineGroup = dropdownService.RenderDDL(await Mediator.Send(new GetDDLMachineGroupQuery { }), true),
                DDLMinMaintainceDurationDays = dropdownService.NumberDDL(1, 30, true)
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(MT_Machine_SetupDTM dtm)
        {
            var rResult = new RResult();
            if (ModelState.IsValid)
            {
                rResult = await Mediator.Send(new MT_Machine_SetupCreateCommand { MT_Machine_SetupDTM = dtm ,SaveChange=true});
            }
            return Json(rResult);

        }

        [HttpPut]
        public async Task<IActionResult> Update(MT_Machine_SetupDTM dtm)
        {
            var rResult = new RResult();
            if (ModelState.IsValid)
            {
                rResult = await Mediator.Send(new MT_Machine_SetupUpdateCommand { MT_Machine_Setup = dtm, SaveChange = true });
            }
            return Json(rResult);

        }
        [HttpPut]
        public async Task<IActionResult> Remove(int machineID)
        {
            var rResult = new RResult();
            if (ModelState.IsValid)
            {
                rResult = await Mediator.Send(new MT_Machine_SetupRemoveCommand { MachineID=machineID });

            }
            return Json(rResult);

        }
        

        [HttpGet]
        public async Task<IActionResult> GetMachineList(DataSourceLoadOptions loadOptions,int companyID,int locationID,int machineGroupID)
        {
            loadOptions.PrimaryKey = new[] {"MachineID"};
            loadOptions.PaginateViaPrimaryKey = true;
            var data = await Mediator.Send(new GetListOfMachineQuery { CompanyID=companyID,LocationID=locationID,MachineGroupID=machineGroupID,LoadOptions=loadOptions});
            return Json(data);

        }
       
    }
}
