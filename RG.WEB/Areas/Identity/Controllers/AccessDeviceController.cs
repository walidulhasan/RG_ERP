using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Interfaces.Services.UserAuthGBS.API.UserInfos;
using RG.Application.ViewModel.Identity.Setup.AccessDevice;
using RG.WEB.Controllers;
using System.Threading.Tasks;

namespace RG.WEB.Areas.Identity.Controllers
{
    [Area("Identity")]
    [Route("Identity/[controller]/[action]")]
    public class AccessDeviceController : BaseController
    {
        private readonly IDropdownService _dropdownService;
        private readonly IUserAccessInfoService _userAccessInfoService;
        private readonly ICurrentUserService _currentUserService;

        public AccessDeviceController(IDropdownService dropdownService, IUserAccessInfoService userAccessInfoService, ICurrentUserService currentUserService)
        {
            _dropdownService = dropdownService;
            _userAccessInfoService = userAccessInfoService;
            _currentUserService = currentUserService;
        }
        public async Task<IActionResult> Index()
        {
            var model = new AccessDeviceIndexVM
            {
                DDLUsers = _dropdownService.DefaultDDL(),
                DDLDeviceDependencyTypes = _dropdownService.RenderDDL(await _userAccessInfoService.DDLUsersDeviceDependencyType(), true)
            };
            return View(model);
        }
        public async Task<JsonResult> DDLUsers(string Predict=null)
        {
            var data = await _userAccessInfoService.DDLUsers(Predict);
            return Json(data);
        }
        public async Task<JsonResult> UpdateUserWiseDeviceDependency(int userID,int deviceDependencyTypeID)
        {
            var data = await _userAccessInfoService.UpdateUserWiseDeviceDependency(userID, deviceDependencyTypeID);
            return Json(data);
        }
        public async Task<JsonResult> UserWiseDeviceDependency(int userID)
        {
            var data = await _userAccessInfoService.UserWiseDeviceDependency(userID);
            return Json(data);
        }
        public async Task<JsonResult> RemoveUserDeviceAuth(int userID)
        {
            var data = await _userAccessInfoService.RemoveUserDeviceAuth(userID);
            return Json(data);
        }

        public async Task<JsonResult> DeviceMacWiseUser(string deviceMac)
        {
            var data = await _userAccessInfoService.DeviceMacWiseUser(deviceMac);
            return Json(data);
        }

        public async Task<JsonResult> RemoveDeviceMacWiseDevice(string deviceMac)
        {
            var data = await _userAccessInfoService.RemoveDeviceMacWiseDevice(deviceMac, _currentUserService.UserID);
            return Json(data);
        }
        

    }
}
