using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Constants;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_UserDepartmentSetups.Commands.Create;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_UserDepartmentSetups.Commands.DataTransferModel;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_UserDepartmentSetups.Commands.Update;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_UserDepartmentSetups.Queries;
using RG.Application.ViewModel.MaterialsManagement.Business.UserWiseDepartmentAssaign;
using RG.WEB.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.MaterialsManagement.Controllers
{
    [Area("MaterialsManagement")]
    [Route("MaterialsManagement/[controller]/[action]")]
    public class UserWiseDepartmentAssaignController : BaseController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserWiseDepartmentAssaignController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult DepartmentAssaign()
        {
            var aaaa = _httpContextAccessor.HttpContext.Request.Cookies[SessionKey.BusinessID];
            var aa = _httpContextAccessor.HttpContext.Request.Headers["Cookie"].FirstOrDefault();
            var aab = _httpContextAccessor.HttpContext.Request.Headers["RG_ERP_APP_COOKIE"].FirstOrDefault();
            var model = new UserWiseDepartmentAssaignVM();
            //  model.UserWiseDepartment= await Mediator.Send(new GetUserWiseDepartmentByUserIdQuery { });
            // model.UserNameList = ddlCommon.RenderDDL(await Mediator.Send(new GetDDLAlgoUserQuery()),true);
            return View(model);
        }

        public async Task<IActionResult> GetUserWiseDepartment(int userID)
        {
            var dataList = await Mediator.Send(new GetUserWiseDepartmentByUserIdQuery { UserID = userID });
            return Json(dataList);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AccessTypeWiseItemsMappingCreate(List<AccessTypeWiseItemsDTM> mapping)
        //{
        //    try
        //    {
        //        var result = await dashboardAccessTypeItemMapRepository.SaveDashboardAccessTypeItemMap(mapping);
        //        return Json(result);
        //    }
        //    catch (Exception e)
        //    {
        //        return Json(e.Message);
        //    }
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> SaveUserWiseDepartmentAssaign(AvailableDepartmentQM availableDepartment)
        //{
        //    var result = await Mediator.Send(new IC_UserDepartmentSetupCreateCommand() { IC_UserDepartmentSetup = availableDepartment.IC_UserDepartmentSetup });

        //    return Json(result);
        //}

        [HttpPost]
        //   [Authorize(Policy = "Permission_FiniteScheduler_MTMachineAndMaintenanceItemAssociation_Create")]
        public async Task<JsonResult> DepartmentAssaign(List<IC_UserDepartmentSetupDTM> dataList)
        {
            var result = await Mediator.Send(new IC_UserDepartmentSetupCreateCommand { UserDepartmentSetup = dataList });
            return Json(result);

        }
        [HttpPost]
        public async Task<JsonResult> RemoveDepartmentAssaign(List<IC_UserDepartmentSetupDTM> removeList)
        {
            var dataResult = await Mediator.Send(new ICUserDepartmentSetupRemoveCommand() { UserDepartmentSetup = removeList });
            return Json(dataResult);
        }
    }
}
