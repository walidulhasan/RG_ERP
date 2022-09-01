using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RG.Application.Common.Models;
using RG.Application.Constants;
using RG.Application.IdentityEntities;
using RG.Application.Interfaces.Services.UserAuthGBS.API.UserInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RG.WEB.Helper
{

    public class AdditionalUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser,ApplicationRole>
    {
        private readonly IUserAccessInfoService _userAccessInfoService;
        private readonly IHttpContextAccessor _contextAccessor;

        public AdditionalUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager
            , IOptions<IdentityOptions> optionsAccessor
            , IUserAccessInfoService userAccessInfoService
            , IHttpContextAccessor contextAccessor
            ) : base(userManager, roleManager, optionsAccessor)
        {
            _userAccessInfoService = userAccessInfoService;
            _contextAccessor = contextAccessor;
        }
        public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);
            var identity = (ClaimsIdentity)principal.Identity;

            int _companyID = 0;
            int _businessID = 0;
            var sessioncompanyID = _contextAccessor.HttpContext.Session.GetInt32(SessionKey.COMPANY_ID);
            var cookieComanyID = _contextAccessor.HttpContext.Request.Cookies[SessionKey.COMPANY_ID];
            if (sessioncompanyID != null)
            {
                _companyID = Convert.ToInt32(sessioncompanyID);
            }
            else if (cookieComanyID != null)
            {
                _companyID = Convert.ToInt32(cookieComanyID);
            }

            var sessionBusinessID = _contextAccessor.HttpContext.Session.GetInt32(SessionKey.BusinessID);
            var cookieBusinessID = _contextAccessor.HttpContext.Request.Cookies[SessionKey.BusinessID];
            if (sessionBusinessID != null)
            {
                _businessID = Convert.ToInt32(sessionBusinessID);
            }
            else if (cookieBusinessID != null)
            {
                _businessID = Convert.ToInt32(cookieBusinessID);
            }
            int ApplicationID = Convert.ToInt32(StaticConfigs.GetConfig("ApplicationID"));

            string hasBusinessID = string.Empty;

            var hasBusinessClaim = identity.FindFirst(SessionKey.BusinessID);
            if (hasBusinessClaim != null)
            {
                hasBusinessID = hasBusinessClaim?.Value;
            }

            //   var claims = new List<Claim>();
            var userInfo = await _userAccessInfoService.GetLoggedUserInfo(user.UserName, ApplicationID, _companyID, _businessID);
            var userdata = userInfo.First();
            //claims.Add(new Claim(ClaimTypes.NameIdentifier, userdata.UserID.ToString()));
            //claims.Add(new Claim(ClaimTypes.Name, userdata.UserName));
            //claims.Add(new Claim(ClaimTypes.Email, userdata.Email ?? ""));
            identity.AddClaim(new Claim(SessionKey.COMPANY_ID, userdata.CompanyID.ToString()));
            identity.AddClaim(new Claim(SessionKey.COMPANY_NAME, userdata.CompanyName));
            identity.AddClaim(new Claim(SessionKey.EMPLOYEE_ID, userdata.EmployeeID.ToString()));
            identity.AddClaim(new Claim(SessionKey.User_EMPLOYEE_Code, userdata.EmployeeCode));
            identity.AddClaim(new Claim(SessionKey.EMPLOYEE_NAME, userdata.EmployeeName));
            identity.AddClaim(new Claim(SessionKey.USER_Designation_Name, userdata.DesignationName ?? ""));
            identity.AddClaim(new Claim(SessionKey.USER_Department_Name, userdata.DepartmentName ?? ""));
            identity.AddClaim(new Claim(SessionKey.ROLE_ID, userdata.RoleID.ToString()));
            //claims.Add(new Claim(ClaimTypes.Role, userdata.RoleName));
            identity.AddClaim(new Claim(SessionKey.Algo_UserID, (userdata.AlgoUserID.HasValue == true ? userdata.AlgoUserID : 0).ToString()));
            identity.AddClaim(new Claim(SessionKey.BusinessID, (userdata.BusinessID.HasValue == true ? userdata.BusinessID : 0).ToString()));
            identity.AddClaim(new Claim(SessionKey.BusinessName, userdata.BusinessName ?? ""));
            identity.AddClaim(new Claim(SessionKey.IsSuperAdmin, userdata.IsSuperAdminRole.ToString()));

            _contextAccessor.HttpContext.Response.Cookies.Append(SessionKey.BusinessID, userdata.BusinessID.ToString());
            _contextAccessor.HttpContext.Response.Cookies.Append(SessionKey.COMPANY_ID, userdata.CompanyID.ToString());

            _contextAccessor.HttpContext.Session.SetInt32(SessionKey.BusinessID, userdata.BusinessID.Value);
            _contextAccessor.HttpContext.Session.SetInt32(SessionKey.COMPANY_ID, userdata.CompanyID.Value);
            // identity.AddClaims(claims);

            var getUserRole = await base.RoleManager.Roles.Where(b=>b.Id== userdata.RoleID).FirstAsync();

            var _userClaims = await base.UserManager.GetClaimsAsync(user);
           var  userClaims = _userClaims.Where(b =>!b.Type.Contains("Permission_")).ToList();
             var _userRoleClaimss = await base.RoleManager.GetClaimsAsync(getUserRole);
            var userRoleClaimss = _userRoleClaimss.Where(b => !b.Type.Contains("Permission_")).ToList();
            identity.AddClaims(userClaims);
            identity.AddClaims(userRoleClaimss);
            return principal;
        }
    }

}
