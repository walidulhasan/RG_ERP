
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.Models;
using RG.Application.Common.Security;
using RG.Application.Constants;
using RG.Application.Contracts.FiniteScheduler.Business.DFS_StockTransactions.Queries;
using RG.Application.IdentityEntities;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using RG.Application.Interfaces.Services.Maxco.Business;
using RG.Application.Interfaces.Services.UserAuthGBS.API.UserInfos;
using RG.WEB.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Wangkanai.Detection.Services;

namespace RG.WEB.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserAccessInfoService _userAccessInfoService;
        //private readonly CustomClaimsCookieSignInHelper<ApplicationUser> _customeClaim;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IStoreProcedureCreateOrAlterService _storeProcedureCreateOrAlterService;
        private readonly IDetectionService _detectionService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IDailyMailService _assetInfoService;

        //private string authConnectionString;
        //private string maxcoConnectionString;
        //private string materialsManagementConnectionString;
        //private string finiteSchedulerConnectionString;
        //private string embroConnectionString;
        //private string aopConnectionString;
        //private string emsConnectionString;
        //private string algoHRConnectionString;

        public HomeController(ILogger<HomeController> logger, IUserAccessInfoService userAccessInfoService
             , SignInManager<ApplicationUser> signInManager
            //, CustomClaimsCookieSignInHelper<ApplicationUser> customeClaim
            , UserManager<ApplicationUser> userManager, IStoreProcedureCreateOrAlterService storeProcedureCreateOrAlterService
            , IDetectionService detectionService, IHttpContextAccessor contextAccessor
            , IConfiguration configuration
            , IDailyMailService assetInfoService)
        {
            _logger = logger;
            _userAccessInfoService = userAccessInfoService;
            //_customeClaim = customeClaim;
            _signInManager = signInManager;
            _userManager = userManager;
            _storeProcedureCreateOrAlterService = storeProcedureCreateOrAlterService;
            _detectionService = detectionService;
            _contextAccessor = contextAccessor;
            _assetInfoService = assetInfoService;
            //authConnectionString = configuration.GetConnectionString("AuthConnection");
            //maxcoConnectionString = configuration.GetConnectionString("MaxcoConnection");
            //materialsManagementConnectionString = configuration.GetConnectionString("MaterialsManagementConnection");
            //finiteSchedulerConnectionString = configuration.GetConnectionString("FiniteSchedulerConnection");
            //embroConnectionString = configuration.GetConnectionString("EmbroConnection");
            //aopConnectionString = configuration.GetConnectionString("AOPConnection");
            //emsConnectionString = configuration.GetConnectionString("EMSConnection");
            //algoHRConnectionString = configuration.GetConnectionString("AlgoHRConnection");
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            //await _dailyMailService.LateDeliveries_HNM();//DateTime.Now.AddDays(-1).Date, DateTime.Now.AddDays(-1).Date
            var u = User;
            //bool isAuthTestServer = authConnectionString.Contains(".190");
            //bool isMaxcoTestServer = maxcoConnectionString.Contains(".190");
            //bool isMaterialsManagementTestServer = materialsManagementConnectionString.Contains(".190");
            //bool isFiniteSchedulerTestServer = finiteSchedulerConnectionString.Contains(".190");
            //bool isEmbroTestServer = embroConnectionString.Contains(".190");
            //bool isAOPTestServer = aopConnectionString.Contains(".190");
            //bool isEMSTestServer = emsConnectionString.Contains(".190");
            //bool isAlgoHRTestServer = algoHRConnectionString.Contains(".190");

            var model = await _userAccessInfoService.GetUserDashboardAccessItems();
            //model.ForEach(x => { x.IsAuthTestServer = isAuthTestServer; x.IsMaxcoTestServer = isMaxcoTestServer;x.IsMaterialsManagementTestServer = isMaterialsManagementTestServer;
            //    x.IsFiniteSchedulerTestServer = isFiniteSchedulerTestServer;x.IsAOPTestServer = isAOPTestServer;x.IsEMSTestServer = isEMSTestServer;x.IsAlgoHRTestServer = isAlgoHRTestServer;
            //}) ;
            return View(model);
        }
        //[Authorize(Policy = "Permission_FiniteScheduler_ApprovalConfiguration_CreateView")]
        public async Task<IActionResult> Privacy()
        {
            //var date = new DateTime(2022, 6, 30);
              //await _assetInfoService.DelayedVoucherPostingCBL(DateTime.Now.AddDays(-6));
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var model = new ErrorViewModel();
            model.RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            var title = exceptionHandlerPathFeature?.Error.Message;


            model.ErrorTitle = title;
            if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
            {
                model.ExceptionMessage = "File error thrown";
                _logger.LogError(model.ExceptionMessage);
            }
            if (exceptionHandlerPathFeature?.Path == "/index")
            {
                model.ExceptionMessage += " from home page";
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<JsonResult> SetSesstionUserCompanyBusiness(int companyId, string companyName, int businessId, string businessName)
        {
            RResult rResult = new RResult();
            try
            {
                var dbUserInfo = await _userManager.FindByNameAsync(User.Identity.Name);
                if (companyId > 0 && businessId > 0)
                {
                    int ApplicationID = Convert.ToInt32(StaticConfigs.GetConfig("ApplicationID"));
                    var userInfo = await _userAccessInfoService.GetLoggedUserInfo(User.Identity.Name, ApplicationID, companyId, businessId);

                    var userdata = userInfo.First();
                    List<Claim> _claim = new List<Claim>();
                    _claim.Add(new Claim(ClaimTypes.Name, userdata.UserName));
                    _claim.Add(new Claim(ClaimTypes.NameIdentifier, userdata.UserID.ToString()));
                    _claim.Add(new Claim(ClaimTypes.Email, userdata.Email ?? ""));
                    _claim.Add(new Claim(SessionKey.COMPANY_ID, userdata.CompanyID.ToString()));
                    _claim.Add(new Claim(SessionKey.COMPANY_NAME, userdata.CompanyName));
                    _claim.Add(new Claim(SessionKey.EMPLOYEE_ID, userdata.EmployeeID.ToString()));
                    _claim.Add(new Claim(SessionKey.User_EMPLOYEE_Code, userdata.EmployeeCode));
                    _claim.Add(new Claim(SessionKey.EMPLOYEE_NAME, userdata.EmployeeName));
                    _claim.Add(new Claim(SessionKey.USER_Designation_Name, userdata.DesignationName ?? ""));
                    _claim.Add(new Claim(SessionKey.USER_Department_Name, userdata.DepartmentName ?? ""));
                    _claim.Add(new Claim(SessionKey.ROLE_ID, userdata.RoleID.ToString()));
                    _claim.Add(new Claim(ClaimTypes.Role, userdata.RoleName));
                    _claim.Add(new Claim(SessionKey.Algo_UserID, (userdata.AlgoUserID.HasValue == true ? userdata.AlgoUserID : 0).ToString()));
                    _claim.Add(new Claim(SessionKey.BusinessID, (userdata.BusinessID.HasValue == true ? userdata.BusinessID : 0).ToString()));
                    _claim.Add(new Claim(SessionKey.BusinessName, userdata.BusinessName ?? ""));
                    _claim.Add(new Claim(SessionKey.IsSuperAdmin, userdata.IsSuperAdminRole.ToString()));
                    _claim.Add(new Claim(ClaimTypes.AuthenticationMethod, CookieAuthenticationDefaults.AuthenticationScheme));
                    _contextAccessor.HttpContext.Response.Cookies.Append(SessionKey.BusinessID, userdata.BusinessID.ToString());
                    _contextAccessor.HttpContext.Response.Cookies.Append(SessionKey.COMPANY_ID, userdata.CompanyID.ToString());

                    var identityUser = await _userManager.FindByNameAsync(User.Identity.Name);
                    //await _customeClaim.SignInUserAsync(identityUser, true, _claim);

                    var authenticationProperties = new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTime.Now.AddDays(2) };
                    await _signInManager.SignInWithClaimsAsync(dbUserInfo, authenticationProperties, _claim);

                }
                rResult.result = 1;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return Json(rResult);
        }

        public async Task<string> Test()
        {

            await Mediator.Send(new DailyOrderFabricWastageExceededLotMailQuery());
            return "";
        }
        //[CheckAuthorize(Policy = "Permission_FiniteScheduler_ApprovalConfiguration_CreateView")]
        public string TestSQLSP()
        {
            var aab = 343;
            //_storeProcedureCreateOrAlterService.CreateOrAlterSQL();
            return "Done";
        }
    }
}
