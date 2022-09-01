using Microsoft.AspNetCore.Http;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RG.WEB.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public bool IsAuthenticated => _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;

        public int UserID
        {
            get
            {
                var claim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier); 
                return (claim != null) ? Convert.ToInt32(claim.Value) : 0;
                 
            }
        }

        public int RoleID
        {
            get
            {
                var claim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == SessionKey.ROLE_ID);
                return (claim != null) ? Convert.ToInt32(claim.Value) : 0;

            }
        }

        public string RoleName
        {
            get
            {
                var claim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role);
                return (claim != null) ? claim.Value : string.Empty;
            }
        }


        public int CompanyID
        {
            get
            {
                var cookieCompany = _httpContextAccessor.HttpContext.Request.Cookies[SessionKey.COMPANY_ID];
                int? _cookieCompany = cookieCompany == null ? null : Convert.ToInt32(cookieCompany);
                var claim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == SessionKey.COMPANY_ID);
               
                var companyID= (claim != null) ? Convert.ToInt32(claim.Value) : 0;
                if(companyID==0 && _cookieCompany.HasValue)
                {
                    companyID = Convert.ToInt32(_cookieCompany.Value);
                }
                return companyID;

            }
        }
        public int AlgoUserID
        {
            get
            {
                var claim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == SessionKey.Algo_UserID);
                return (claim != null) ? Convert.ToInt32(claim.Value) : 0;

            }
        }
        public string CompanyName
        {
            get
            {
                var claim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == SessionKey.COMPANY_NAME);
                return (claim != null) ? claim.Value : string.Empty;

            }
        }
        public string UserName => _httpContextAccessor.HttpContext.User.Identity.Name;

        public bool IsSuperAdminRole
        {
            get
            {
                var claim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == SessionKey.IsSuperAdmin);
                return (claim != null) ? Convert.ToBoolean(claim.Value) :false;

            }
        }
        public string UserEmail
        {
            get
            {
                var claim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type ==ClaimTypes.Email);
                return (claim != null) ? claim.Value : string.Empty;

            }
        }

        public string UserType =>  throw new NotImplementedException();
        public int EmployeeID
        {
            get
            {
                var claim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == SessionKey.EMPLOYEE_ID);
                return (claim != null) ? Convert.ToInt32(claim.Value) : 0;
            }
        }
        public string EmployeeCode
        {
            get
            {
                var claim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == SessionKey.User_EMPLOYEE_Code);
                return (claim != null) ? claim.Value : string.Empty;
            }
        }

        public int BusinessID 
        {
            get
            {
                var claim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == SessionKey.BusinessID);
                return (claim != null) ? Convert.ToInt32(claim.Value) : 0;
            }
        }

        public bool HasClaimAccess(string policyType)
        {            
                var claim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == policyType);
                return claim != null;
        }
    }
}
