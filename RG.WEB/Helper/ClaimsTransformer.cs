using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using RG.Application.Common.Models;
using RG.Application.Constants;
using RG.Application.Interfaces.Services.UserAuthGBS.API.UserInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RG.WEB.Helper
{

    public class ClaimsTransformer //: IClaimsTransformation
    {
        /*
        private readonly IUserAccessInfoService _userAccessInfoService;
        private readonly IHttpContextAccessor _contextAccessor;
        public ClaimsTransformer(IUserAccessInfoService userAccessInfoService, IHttpContextAccessor contextAccessor)
        {
            _userAccessInfoService = userAccessInfoService;
            _contextAccessor = contextAccessor;
        }
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            int _companyID = 0;
            int _businessID = 0;
            var companyID = _contextAccessor.HttpContext.Request.Cookies[SessionKey.COMPANY_ID];
            if(companyID != null)
            {
                _companyID = Convert.ToInt32(companyID);
            }
            var businessID = _contextAccessor.HttpContext.Request.Cookies[SessionKey.BusinessID];
            if (businessID != null)
            {
                _businessID = Convert.ToInt32(businessID);
            }
            int ApplicationID = Convert.ToInt32(StaticConfigs.GetConfig("ApplicationID"));
            if (_contextAccessor.HttpContext.User.Identity.Name != null  && _businessID == 0)
            {
                var userInfo = await _userAccessInfoService.GetLoggedUserInfo(_contextAccessor.HttpContext.User.Identity.Name, ApplicationID, _companyID, _businessID);
                var userdata = userInfo.First();
                ((ClaimsIdentity)principal.Identity).AddClaim(new Claim(ClaimTypes.Name, userdata.UserName));
                ((ClaimsIdentity)principal.Identity).AddClaim(new Claim(ClaimTypes.NameIdentifier, userdata.UserID.ToString()));
                ((ClaimsIdentity)principal.Identity).AddClaim(new Claim(ClaimTypes.Email, userdata.Email ?? ""));
                ((ClaimsIdentity)principal.Identity).AddClaim(new Claim(SessionKey.COMPANY_ID, userdata.CompanyID.ToString()));
                ((ClaimsIdentity)principal.Identity).AddClaim(new Claim(SessionKey.COMPANY_NAME, userdata.CompanyName));
                ((ClaimsIdentity)principal.Identity).AddClaim(new Claim(SessionKey.EMPLOYEE_ID, userdata.EmployeeID.ToString()));
                ((ClaimsIdentity)principal.Identity).AddClaim(new Claim(SessionKey.User_EMPLOYEE_Code, userdata.EmployeeCode));
                ((ClaimsIdentity)principal.Identity).AddClaim(new Claim(SessionKey.EMPLOYEE_NAME, userdata.EmployeeName));
                ((ClaimsIdentity)principal.Identity).AddClaim(new Claim(SessionKey.USER_Designation_Name, userdata.DesignationName ?? ""));
                ((ClaimsIdentity)principal.Identity).AddClaim(new Claim(SessionKey.USER_Department_Name, userdata.DepartmentName ?? ""));
                ((ClaimsIdentity)principal.Identity).AddClaim(new Claim(SessionKey.ROLE_ID, userdata.RoleID.ToString()));
                ((ClaimsIdentity)principal.Identity).AddClaim(new Claim(ClaimTypes.Role, userdata.RoleName));
                ((ClaimsIdentity)principal.Identity).AddClaim(new Claim(SessionKey.Algo_UserID, (userdata.AlgoUserID.HasValue == true ? userdata.AlgoUserID : 0).ToString()));
                ((ClaimsIdentity)principal.Identity).AddClaim(new Claim(SessionKey.BusinessID, (userdata.BusinessID.HasValue == true ? userdata.BusinessID : 0).ToString()));
                ((ClaimsIdentity)principal.Identity).AddClaim(new Claim(SessionKey.BusinessName, userdata.BusinessName ?? ""));
                ((ClaimsIdentity)principal.Identity).AddClaim(new Claim(SessionKey.IsSuperAdmin, userdata.IsSuperAdminRole.ToString()));
               // ((ClaimsIdentity)principal.Identity).AddClaim(new Claim(ClaimTypes.AuthenticationMethod, CookieAuthenticationDefaults.AuthenticationScheme));
               
                _contextAccessor.HttpContext.Response.Cookies.Append(SessionKey.BusinessID, userdata.BusinessID.ToString());
                _contextAccessor.HttpContext.Response.Cookies.Append(SessionKey.COMPANY_ID, userdata.CompanyID.ToString());
            }
            


            ((ClaimsIdentity)principal.Identity).AddClaim(new Claim("now", DateTime.Now.ToString()));
            return principal;
        }
        */
    }
}
