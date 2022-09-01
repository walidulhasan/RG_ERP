using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Contracts.AlgoHR.Setups.UserDepartmentAccess.Commands.Create;
using RG.Application.Contracts.AlgoHR.Setups.UserDepartmentAccess.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Setups.UserDepartmentAccess.Queries;
using RG.Application.Contracts.UserAuthGBS.Setup.User.Queries;
using RG.Application.IdentityEntities;
using RG.Application.ViewModel.AlgoHR.Setup.UserDepartmentAccess;
using RG.WEB.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RG.WEB.Areas.AlgoHR.Controllers
{
    [Area("AlgoHR")]
    [Route("AlgoHR/[controller]/[action]")]
    public class UserDepartmentAccessController : BaseController
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDropdownService _dropdownService;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserDepartmentAccessController(ICurrentUserService currentUserService, IDropdownService dropdownService
            , UserManager<ApplicationUser> userManager)
        {
            _currentUserService = currentUserService;
            _dropdownService = dropdownService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            UserDepartmentAccessVM model = new()
            {
                DDLUser = _dropdownService.DefaultDDL()
            };

            return View(model);
        }
        public IActionResult Test()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> Create(List<UserDepartmentAccessCreateDTM> selectedData)
        {
            var data = await Mediator.Send(new UserDepartmentAccessCreateCommand { SelectedData = selectedData });
            return Json(data);
        }
        public async Task<JsonResult> GetUserDepartmentAccessList(DataSourceLoadOptions loadOptions,int userID)
        {
            var data= await Mediator.Send(new GetUserDepartmentAccessListQuery { UserID = userID,LoadOptions=loadOptions });
            return Json(data);
        }
        #region Json Dropdown All
        public async Task<JsonResult> GetDDLUserCompany(bool IsAll = false)
        {
            var data = await Mediator.Send(new GetDDLUserCompanyQuery() { UserID = _currentUserService.UserID, IsAll = IsAll });
            return Json(_dropdownService.RenderDDL(data, true));
        }
        public async Task<JsonResult> GetDDLUserDivision(List<int> Companys, bool IsAll = false,string Predict=null)
        {
            var data = await Mediator.Send(new GetDDLUserDivisionQuery() { UserID = _currentUserService.UserID, CompanyID = Companys, IsAll = IsAll,Predict=Predict });
            return Json(_dropdownService.RenderDDL(data, true));
        }
        public async Task<JsonResult> GetDDLUserDepartment(List<int> Companys, List<int> Divisions, bool IsAll = false,string Predict = null)
        {
            var data = await Mediator.Send(new GetDDLUserDepartmentQuery()
            {
                UserID = _currentUserService.UserID,
                CompanyID = Companys,
                DivisionID = Divisions,
                IsAll = IsAll,
                Predict=Predict
            });

            return Json(_dropdownService.RenderDDL(data, true));
        }
        public async Task<JsonResult> GetDDLUserSection(List<int> Companys, List<int> Divisions, List<int> Departments, bool IsAll = false,string Predict = null)
        {
            var data = await Mediator.Send(new GetDDLUserSectionQuery()
            {
                UserID = _currentUserService.UserID,
                CompanyID = Companys,
                DivisionID = Divisions,
                DepartmentID = Departments,
                IsAll = IsAll,
                Predict= Predict
            });

            return Json(_dropdownService.RenderDDL(data, true));
        }
        public async Task<JsonResult> GetDDLUserSectionEmployee(List<int> Companys, List<int> Divisions, List<int> Departments,List<int> Sections
            ,List<int>Designations,List<int>Locations,int? EmployeeTypes=null,string Gender=null,bool? ActiveStatus=null
            , bool IsAll = false,string Predict=null)
        {
            var data = await Mediator.Send(new GetDDLUserSectionEmployeeQuery()
            {
                UserID = _currentUserService.UserID,
                CompanyID = Companys,
                DivisionID = Divisions,
                DepartmentID = Departments,
                IsAll = IsAll,
                SectionID=Sections,
                ActiveStatus=ActiveStatus,
                Locations=Locations,
                Designations =Designations,
                EmployeeTypes =EmployeeTypes,
                Gender=Gender,
                Predict=Predict
            });

            return Json(_dropdownService.RenderDDL(data, true));
        }
        public async Task<JsonResult> GetDDLUserEmployee(string Predict=null)
        {
            return Json(await Mediator.Send(new GetDDLUserEmployeeQuery() { Predict = Predict }));
        }
        public async Task<JsonResult> GetDDLCustomUserEmployee(string Predict = null)
        {
            return Json(await Mediator.Send(new GetDDLCustomUserEmployeeQuery() { Predict = Predict }));
        }
        
        #endregion
    }
}
