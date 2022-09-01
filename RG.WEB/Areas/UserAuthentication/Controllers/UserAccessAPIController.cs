using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.Models;
using RG.Application.Contracts.UserAuthGBS.API.UserInfos.Commands;
using RG.Application.Contracts.UserAuthGBS.API.UserInfos.Queries;
using RG.WEB.Controllers;

namespace RG.WEB.Areas.UserAuthentication.Controllers
{

    [Route("api/UserAuthentication/[controller]")]
    public class UserAccessAPIController : BaseAPIController
    {
        private readonly ICurrentUserService _currentUserService;

        public UserAccessAPIController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;

        }
        [HttpGet("GetUserMenu")]
    
        public async Task<string> GetUserMenu()
        {
            var data = await Mediator.Send(new GetUserMenuQuery());
            return data;
        }
        [HttpGet("GetDDLCompany")]
        public async Task<List<SelectListItem>> GetDDLCompany()
        {
            return await Mediator.Send(new GetDDLCompanyQuery());
        }
        [HttpGet("GetDDLUserBusiness")]
        public async Task<List<SelectListItem>> GetDDLUserBusiness([FromQuery] int UserID, [FromQuery] int companyID)
        {
            return await Mediator.Send(new GetDDLUserBusinessQuery() { UserID=UserID,CompanyID = companyID});
        }
        [Authorize]
        [HttpPost("ChangeUserPassword")]
        public async Task<RResult> ChangeUserPassword([FromForm]string CurrentPassword, [FromForm]string NewPassword)
        {
            return await Mediator.Send(new ChangePasswordCommand() {UserID = _currentUserService.UserID,CurrentPassword= CurrentPassword,NewPassword=NewPassword });

        }
        [HttpGet("GetMobileDeviceSercetCode")]
        public async Task<string> GetMobileDeviceSercetCode()
        {
            var data = StaticConfigs.GetConfig("MobileSecretCode");
            return await Task.FromResult(data);
        }

        
    }
    
}
