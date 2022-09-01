using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.Embro.CompanyInfos.Queries;
using RG.Application.Contracts.FiniteScheduler.MT_MachineAndMaintenanceItemAssociations.Commands.Create;
using RG.Application.Contracts.FiniteScheduler.MT_MachineAndMaintenanceItemAssociations.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MachineAndMaintenanceItemAssociations.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MachineAndMaintenanceItemAssociations.Commands.Update;
using RG.Application.Contracts.FiniteScheduler.Setups.MT_MachineAndMaintenanceItemAssociations.Queries;
using RG.Application.ViewModel.FiniteScheduler.Setup.MachineMaintenanceItemAssociation;
using RG.WEB.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RG.WEB.Areas.FiniteScheduler.Controllers
{
    [Area("FiniteScheduler")]
    [Route("FiniteScheduler/[controller]/[action]")]
    public class MachineMaintenanceItemAssociationController : BaseController
    {
        private readonly IDropdownService dropdownService;
        public MachineMaintenanceItemAssociationController(IDropdownService _dropdownService)
        {
            dropdownService = _dropdownService;
        }
        #region Actions
        public async Task<IActionResult> Create()
        {
            var model = new AssociationVM
            {
                DDLLocation = dropdownService.DefaultDDL(),
                DDLCompany = dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), true),
                DDLMachine = dropdownService.DefaultDDL()
            };
            return View(model);
        }

        #endregion

        #region Json Functions
        [HttpPost]
        //   [Authorize(Policy = "Permission_FiniteScheduler_MTMachineAndMaintenanceItemAssociation_Create")]
        public async Task<JsonResult> Create(List<AssociationDTM> dataList)
        {
            var result = await Mediator.Send(new MachineAndMaintenanceItemAssociationCreateCommand { Association = dataList });
            return Json(result);

        }
        public async Task<JsonResult> GetMachineWiseMaintenanceItemList(int machineID)
        {
            var data = await Mediator.Send(new GetMachineWiseMaintenanceItemListQuery { MachineID = machineID });
            return Json(data);
        }

        [HttpPost]
        public async Task<JsonResult> RemoveAssociation(List<UpdateAssociationDTM> removeList)
        {
            var dataResult = await Mediator.Send(new RemoveAssociationItemCommand() {removeModel = removeList });
            return Json(dataResult);
        }

        #endregion
    }
}
