
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.Models;
using RG.Application.Constants;
using RG.Application.Enums;
using RG.Application.IdentityEntities;
using RG.Application.Interfaces.Services.UserAuthGBS.API.UserInfos;
using RG.WEB.Areas.Identity.Data;
using RG.WEB.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Wangkanai.Detection.Services;

namespace RG.WEB.Areas.Identity.Controllers
{
    [Area("Identity")]
    [Route("Identity/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IUserAccessInfoService _userAccessInfoService;
        //private readonly CustomClaimsCookieSignInHelper<ApplicationUser> _customeClaim;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IDropdownService _dropdownService;
        private readonly IDetectionService _detectionService;
        public AccountController(SignInManager<ApplicationUser> signInManager, ILogger<AccountController> logger,
            UserManager<ApplicationUser> userManager, IUserAccessInfoService userAccessInfoService,
            //CustomClaimsCookieSignInHelper<ApplicationUser> customeClaim,
            IHttpContextAccessor contextAccessor, IDropdownService dropdownService, IDetectionService detectionService
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _userAccessInfoService = userAccessInfoService;
            //_customeClaim = customeClaim;
            _contextAccessor = contextAccessor;
            _dropdownService = dropdownService;
            _detectionService = detectionService;
        }
        [HttpGet]
        public IActionResult Login(string returnUrl = null, string deviceIdentity = null,
                                    string requestDeviceName = null, string AppVersion = null,
                                    string requestDeviceModel = null, string requestSecretCode = null)
        {
            LoginVM model = new LoginVM();
            model.DeviceIdentity = deviceIdentity ?? "";
            model.RequestDeviceName = requestDeviceName;
            model.AppVersion = AppVersion;
            model.RequestDeviceModel = requestDeviceModel;
            model.RequestSecretCode = requestSecretCode;
            model.ReturnUrl = returnUrl ?? Url.Content("~/");

            return View(model);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model, string returnUrl = "")
        {
            //model.DeviceIdentity = model.DeviceIdentity == null ? "4c8e7d0b0580d359" : model.DeviceIdentity;
            model.DevicePlatform = _detectionService.Platform.Name.ToString();
            model.LoginDeviceType = _detectionService.Device.Type.ToString();
            model.ReturnUrl = returnUrl;
            if (ModelState.IsValid)
            {
                var dbUserInfo = await _userManager.FindByNameAsync(model.UserName);

                if (dbUserInfo == null)
                {
                    model.Message = "You are not register User.";
                    return View(model);
                }
                if (dbUserInfo.IsActive == false && dbUserInfo.IsRemoved == true)
                {
                    model.Message = "You are not active is this moment.";
                    return View(model);
                }
                var result = await _userManager.CheckPasswordAsync(dbUserInfo, model.Password);
                if (result)
                {
                    bool isAuthenticated = await IsDevieDependent(dbUserInfo, model); //true; 
                    if (isAuthenticated)
                    {
                        #region Block

                        int ApplicationID = Convert.ToInt32(StaticConfigs.GetConfig("ApplicationID"));

                        int? passCompanyID = model.CompanyID > 0 ? model.CompanyID : null;
                        int? passBusinessID = model.BusinessID > 0 ? model.BusinessID : null;

                        var userInfo = await _userAccessInfoService.GetLoggedUserInfo(model.UserName, ApplicationID, passCompanyID, passBusinessID);
                        if (userInfo.Count > 1)
                        {
                            model.UserId = dbUserInfo.Id;
                            model.IsNeedBusinessID = 1;
                            model.DDLUserCompany = userInfo.GroupBy(g => new { g.CompanyID, g.CompanyName })
                                .Select(s => new SelectListItem()
                                {
                                    Text = s.Key.CompanyName,
                                    Value = s.Key.CompanyID.ToString()
                                }).ToList();

                            var companyRow = model.DDLUserCompany[0];
                            var SelectedcompanyID = Convert.ToInt32(companyRow.Value);
                            var business = userInfo.Where(b => b.CompanyID == SelectedcompanyID)
                                .GroupBy(g => new { g.BusinessID, g.BusinessName })
                                .Select(s => new SelectListItem()
                                {
                                    Text = s.Key.BusinessName,
                                    Value = s.Key.BusinessID.ToString()
                                }).ToList();
                            model.DDLUserBusiness = business;
                            /*
                            var userdata = userInfo.First();
                            List<Claim> _claim = new()
                            {
                                new Claim(ClaimTypes.Email, userdata.Email ?? ""),
                                //_claim.Add(new Claim(ClaimTypes.Email, userdata.Email ?? ""));
                                new Claim(SessionKey.EMPLOYEE_ID, userdata.EmployeeID.ToString()),
                                new Claim(SessionKey.User_EMPLOYEE_Code, userdata.EmployeeCode ?? ""),
                                new Claim(SessionKey.EMPLOYEE_NAME, userdata.EmployeeName),
                                new Claim(SessionKey.ROLE_ID, "0"),
                                new Claim(SessionKey.USER_Designation_Name, userdata.DesignationName ?? ""),
                                new Claim(SessionKey.USER_Department_Name, userdata.DepartmentName ?? ""),
                                new Claim(SessionKey.Algo_UserID, (userdata.AlgoUserID.HasValue == true ? userdata.AlgoUserID : 0).ToString()),
                                new Claim(SessionKey.IsSuperAdmin, userdata.IsSuperAdminRole.ToString())
                            };
                            await _customeClaim.SignInUserAsync(dbUserInfo, model.RememberMe, _claim);
                            */
                            return View(model);
                        }
                        else if (userInfo.Count == 1)
                        {

                            var userdata = userInfo.First();
                            List<Claim> _claim = new()
                            {

                                new Claim(ClaimTypes.NameIdentifier, dbUserInfo.Id.ToString()),
                                new Claim(ClaimTypes.Name, dbUserInfo.UserName),
                                new Claim(ClaimTypes.Email, userdata.Email ?? ""),
                                //new Claim(SessionKey.COMPANY_ID, userdata.CompanyID.ToString()),
                                //new Claim(SessionKey.COMPANY_NAME, userdata.CompanyName ?? ""),
                                //new Claim(SessionKey.EMPLOYEE_ID, userdata.EmployeeID.ToString()),
                                //new Claim(SessionKey.User_EMPLOYEE_Code, userdata.EmployeeCode ?? ""),
                                //new Claim(SessionKey.EMPLOYEE_NAME, userdata.EmployeeName),
                                //new Claim(SessionKey.ROLE_ID, userdata.RoleID.ToString()),
                                new Claim(ClaimTypes.Role, userdata.RoleName),
                                //new Claim(SessionKey.USER_Designation_Name, userdata.DesignationName ?? ""),
                                //new Claim(SessionKey.USER_Department_Name, userdata.DepartmentName ?? ""),
                                //new Claim(SessionKey.Algo_UserID, (userdata.AlgoUserID.HasValue == true ? userdata.AlgoUserID : 0).ToString()),
                                //new Claim(SessionKey.BusinessID, (userdata.BusinessID.HasValue == true ? userdata.BusinessID : 0).ToString()),
                                //new Claim(SessionKey.BusinessName, userdata.BusinessName ?? ""),
                                //new Claim(SessionKey.IsSuperAdmin, userdata.IsSuperAdminRole.ToString()),
                                new Claim(ClaimTypes.AuthenticationMethod, CookieAuthenticationDefaults.AuthenticationScheme),
                                //New 
                                new Claim(ClaimTypes.SerialNumber, userdata.CompanyID.ToString()),
                                new Claim(ClaimTypes.GroupSid, userdata.BusinessID.ToString()),
                                new Claim(ClaimTypes.Spn, (userdata.AlgoUserID.HasValue == true ? userdata.AlgoUserID : 0).ToString()),
                                new Claim(ClaimTypes.PostalCode, userdata.EmployeeCode ?? ""),
                                new Claim(ClaimTypes.StreetAddress, userdata.IsSuperAdminRole.ToString()),

                            };
                            _contextAccessor.HttpContext.Response.Cookies.Append(SessionKey.BusinessID, userdata.BusinessID.ToString());
                            _contextAccessor.HttpContext.Response.Cookies.Append(SessionKey.COMPANY_ID, userdata.CompanyID.ToString());

                            _contextAccessor.HttpContext.Session.SetInt32(SessionKey.BusinessID, userdata.BusinessID.Value);
                            _contextAccessor.HttpContext.Session.SetInt32(SessionKey.COMPANY_ID, userdata.CompanyID.Value);


                            /*
                            //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme    
                            var identity = new ClaimsIdentity(_claim, CookieAuthenticationDefaults.AuthenticationScheme);
                            //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
                            var principal = new ClaimsPrincipal(identity);

                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                                            new AuthenticationProperties { IsPersistent = model.RememberMe }
                                            );
                            */
                            //await _customeClaim.SignInUserAsync(dbUserInfo, model.RememberMe, _claim);
                            var authenticationProperties = new AuthenticationProperties { IsPersistent = model.RememberMe, ExpiresUtc = DateTime.Now.AddDays(2) };
                            await _signInManager.SignInWithClaimsAsync(dbUserInfo, authenticationProperties, _claim);

                            return LocalRedirect(returnUrl);// new add
                        }
                        else
                        {
                            return View(model);
                        }

                        #endregion
                    }
                    else
                    {
                        var isNewApp = GetIsNewAppUsed(model.RequestSecretCode);
                        //if (isNewApp == false )
                        //{
                            //<a href="http://www.robintexbd.com/" target="_blank">Download App</a>\

                            model.AppLink = "<a href='http://www.robintexbd.com/' target='_blank'>Download App</a>";
                        //}

                        model.Message = "This Deivce Is Not Registered For This User";
                        return View(model);
                    }
                    //return LocalRedirect(returnUrl); // old 

                }
                model.Message = "User Name or Password is not correct.";
                return View(model);

            }
            else
            {
                model.Message = "Enter User Name and Password.";
                return View(model);
            }

        }

        public async Task<IActionResult> LogOut(string deviceType)
        {
            if (deviceType == "Mobile")
            {
                var secretCode = StaticConfigs.GetConfig("MobileSecretCode");
                var deviceIdentity = await _userAccessInfoService.AuthenticatedUserDeviceIdentity(deviceType);
                LoginVM model = new() { DeviceIdentity = deviceIdentity };
                model.RequestSecretCode = secretCode;

                await HttpContext.SignOutAsync();
                await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
                return View("Login", model);
            }
            else
            {
                await HttpContext.SignOutAsync();
                await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            }
            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }


        private async Task<bool> IsDevieDependent(ApplicationUser dbUserInfo, LoginVM model)
        {
            bool isAuthenticated = true;

            bool IsNewAppUsed = GetIsNewAppUsed(model.RequestSecretCode);

            if (dbUserInfo.DeviceDependencyTypeID == (int)enum_DeviceDependencyType.DeviceIndependent)
            {

            }
            else if (dbUserInfo.DeviceDependencyTypeID == (int)enum_DeviceDependencyType.WebIndependentAndMobileDependent)
            {

                if (model.LoginDeviceType == "Mobile")
                {
                    if (model.DevicePlatform.ToUpper() == "IOS")
                    {
                        ///Develop Here 
                        //-----
                        ///now there no rules.
                    }
                    else
                    {

                        if (!string.IsNullOrEmpty(model.DeviceIdentity))
                        {
                            isAuthenticated = await _userAccessInfoService.AuthenticateUserDevice(dbUserInfo.Id, model.DeviceIdentity, model.LoginDeviceType, model.AppVersion);
                        }
                        else
                            isAuthenticated = false;//set to false when full app works perfectly

                        ///New Add for New App
                        if (IsNewAppUsed && model.AppVersion == null)
                        {
                            isAuthenticated = false;
                        }

                    }
                }
            }
            else if (dbUserInfo.DeviceDependencyTypeID == (int)enum_DeviceDependencyType.MobileDependent)
            {
                if (model.LoginDeviceType == "Mobile")
                {
                    if (model.DevicePlatform.ToUpper() == "IOS")
                    {
                        ///Develop Here 
                        //-----
                        ///now there no rules.
                    }
                    else
                    {

                        if (!string.IsNullOrEmpty(model.DeviceIdentity))
                        {
                            isAuthenticated = await _userAccessInfoService.AuthenticateUserDevice(dbUserInfo.Id, model.DeviceIdentity, model.LoginDeviceType, model.AppVersion);
                        }
                        else
                            isAuthenticated = false;//set to false when full app works perfectly

                        ///New Add for New App
                        if (IsNewAppUsed && model.AppVersion == null)
                        {
                            isAuthenticated = false;
                        }
                    }
                }
                else
                {
                    isAuthenticated = false;
                }
            }
            else
            {

            }
            return isAuthenticated;
        }


        private bool GetIsNewAppUsed(string RequestSecretCode)
        {
            string IsNewAppActive = StaticConfigs.GetConfig("IsNewAppActive");
            string MobileSecretCode = StaticConfigs.GetConfig("MobileSecretCode");

            bool isAuthenticated = false;
            if (IsNewAppActive == "1" && RequestSecretCode != null && RequestSecretCode.Length > 0)
            {
                if (RequestSecretCode != MobileSecretCode)
                {
                    isAuthenticated = true;
                }
            }
            return isAuthenticated;
        }
    }
}
