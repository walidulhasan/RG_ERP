using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Constants;
using RG.Application.Contracts.AlgoHR.Business.LateAttendanceWarningLetterMasters.Commands;
using RG.Application.Contracts.AlgoHR.Business.LateAttendanceWarningLetterMasters.Query;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpAttendances.Query;
using RG.Application.Contracts.AlgoHR.Setups.Tbl_AttendanceStatuss.Query;
using RG.Application.Contracts.AlgoHR.Setups.Tbl_EmpType.Queries;
using RG.Application.Contracts.AlgoHR.Setups.Tbl_Location.Queries;
using RG.Application.Contracts.AlgoHR.Setups.Tbl_Shift.Queries;
using RG.Application.Contracts.AlgoHR.Setups.UserDepartmentAccess.Queries;
using RG.Application.Contracts.Embro.CompanyInfos.Queries;
using RG.Application.Enums;
using RG.Application.ViewModel.AlgoHR.Business.EmployeeAttendance;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.AlgoHR.Controllers
{
    [Area("AlgoHR")]
    [Route("AlgoHR/[controller]/[action]")]
    public class EmployeeAttendanceController : BaseController
    {
        private readonly IDropdownService _dropdownService;
        private readonly ICurrentUserService _currentUserService;
        public EmployeeAttendanceController(IDropdownService dropdownService, ICurrentUserService currentUserService)
        {
            _dropdownService = dropdownService;
            _currentUserService = currentUserService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Late()
        {
            var model = new LateVM()
            {
                DDLCompany = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), true),
                DDLOfficeDivision = _dropdownService.DefaultDDL(),
                DDLDepartment = _dropdownService.DefaultDDL(),
                DDLSection = _dropdownService.DefaultDDL(),
                DDLYear = _dropdownService.NumberDDL(DateTime.Now.Year - 1, DateTime.Now.Year, false, DateTime.Now.Year),
                DDLMonth = Enumerable.Range(1, 12).Select(i => new SelectListItem { Value = i.ToString(), Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(i) }).ToList(),
                Year = DateTime.Now.Year,
                Month = DateTime.Now.Month
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetLateEmployeesList(DataSourceLoadOptions loadOptions, int companyID, int divisionID, int departmentID, int sectionID, int year, int month)
        {
            loadOptions.PrimaryKey = new[] { "EmployeeID" };
            loadOptions.PaginateViaPrimaryKey = true;
            var data = await Mediator.Send(new GetLateEmployeesListQuery { CompanyID = companyID, DivisionID = divisionID, DepartmentID = departmentID, SectionID = sectionID, Year = year, Month = month });
            var retData = DataSourceLoader.Load(data, loadOptions);
            return Json(retData);

        }
        public async Task<JsonResult> GetEmployeeLateHistory(int employeeID, string employeeCode, int year, int month)
        {
            var data = await Mediator.Send(new GetEmployeeLateHistoryQuery { EmployeeID = employeeID, EmployeeCode = employeeCode, Year = year, Month = month });
            var warningLetters = await Mediator.Send(new GetEmployeeWiseLateAttendanceWarningLetterQuery { EmployeeID = employeeID, Year = year, Month = month });
            var retData = new
            {
                History = data,
                WarningLetter = warningLetters
            };
            return Json(retData);
        }
        public async Task<JsonResult> IssueWarningLetter(int employeeID, int year, int month)
        {
            var data = await Mediator.Send(new LateAttendanceWarningLetterIssueCommand { EmployeeID = employeeID, Year = year, Month = month });

            return Json(data);
        }
        public async Task<IActionResult> WarningLetterPrint(int letterMasterID, string type, string ReportFormat)
        {
            string reportName = type == "EN" ? $"/{ReportFolder.AlgoHRFolder}/LateAttendanceWarningLetter" : $"/{ReportFolder.AlgoHRFolder}/LateAttendanceWarningLetterBN";

            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "LetterMasterID", letterMasterID }
            };
            var connectionString = (int)enum_ServerType.Algo_HRM;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

        }

        public async Task<IActionResult> AttendanceInfo()
        {
            AttendanceInfoVM model = new AttendanceInfoVM();
            model.DateFrom = DateTime.Now.ToString("dd-MMM-yyyy");
            model.DateTo = DateTime.Now.ToString("dd-MMM-yyyy");
            model.DDLCompany = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLUserCompanyQuery { UserID = _currentUserService.UserID, IsAll = false }), true);
            model.DDLDivision = _dropdownService.DefaultDDL();
            model.DDLDepartment = _dropdownService.DefaultDDL();
            model.DDLSection = _dropdownService.DefaultDDL();
            model.DDLDesignation = _dropdownService.DefaultDDL();
            model.DDLGender = _dropdownService.DDLGender(true);
            model.DDLEmpType = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLTbl_EmpTypeQuery()), true);
            model.DDLStatus = _dropdownService.YesNoDDL(true, 1, "In Active", "Active");
            model.DDLLocation = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLTbl_LocationCompanyWiseQuery()), true);
            model.DDLShiftAssigne = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLAttendanceShiftQuery()), true);
            model.DDLEmployee = _dropdownService.DefaultDDL();

            model.DDLAttendanceStatus = new List<SelectListItem>()
            {
                new SelectListItem(){Text="All" ,Value="2,3,7"},
                new SelectListItem(){Text="Present" ,Value="3,7"},
                new SelectListItem(){Text="Absent" ,Value="2"},
            };

            return View(model);
        }


        public async Task<IActionResult> MyAttendanceInfo()
        {
            MyAttendanceInfoVM model = new MyAttendanceInfoVM();
            model.EmployeeCode = _currentUserService.EmployeeCode;
            model.EmployeeID = _currentUserService.EmployeeID;

            model.DateFrom = DateTime.Now.ToString("dd-MMM-yyyy");
            model.DateTo = DateTime.Now.ToString("dd-MMM-yyyy");
            /*
                        model.DDLAttendanceStatus = new List<SelectListItem>()
                        {
                            new SelectListItem(){Text="All" ,Value=""},
                            new SelectListItem(){Text="Present" ,Value="3,7"},
                            new SelectListItem(){Text="Absent" ,Value="2"},
                        };
                        */
            model.DDLAttendanceStatus = new List<SelectListItem>() { new SelectListItem() { Text = "All", Value = "" } };
            model.DDLAttendanceStatus.AddRange(await Mediator.Send(new GetDDLAttendanceStatusQuery()));
            model.AttendanceStatus = "";
            return View(model);
        }

        public async Task<JsonResult> GetMyAttendanceData(DataSourceLoadOptions loadOptions, string AttendanceStatus, DateTime? DateFrom = null, DateTime? DateTo = null)
        {
            var query = new GetMyAttendanceInfoQuery();


            query.EmployeeID = _currentUserService.EmployeeID;
            query.AttendanceStatus = AttendanceStatus;
            query.DateFrom = (DateFrom != null && DateFrom.HasValue == true) ? DateFrom.Value : DateTime.Now.Date;
            query.DateTo = (DateTo != null && DateTo.HasValue == true) ? DateTo.Value : DateTime.Now.Date;
            query.loadOptions = loadOptions;

            if (query.DateFrom > query.DateTo)
            {
                var toDate = query.DateFrom;
                query.DateFrom = query.DateTo;
                query.DateTo = toDate;
            }
            if (DateTime.Now.AddMonths(-3) > query.DateFrom)
            {
                query.DateFrom = DateTime.Now.AddMonths(-3).Date;
            }

            var data = await Mediator.Send(query);
            return Json(data);
        }

        #region Report
        public async Task<IActionResult> EmployeeAttendanceAll(string Companies = null, string Divisions = null, string Departments = null, string Sections = null
                        , string Designations = null, string EmployeeCodes = null, string DateFrom = null, string DateTo = null, string AttendanceStatus = null
                       , string PresentStatus = null, string Shifts = null, string EmployeeTypeID = "0", string EmployeeStatusID = "1", string Gender = null, string Location = null
              , string ReportFormat = "PDF")
        {
            string reportName = $"/{ReportFolder.AlgoHRFolder}/EmployeeAttendanceAll";
            PresentStatus = string.IsNullOrEmpty(PresentStatus) ? "All" : PresentStatus;

            IDictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Companies", Companies);
            parameters.Add("Divisions", Divisions);
            parameters.Add("Departments", Departments);
            parameters.Add("Sections", Sections);
            parameters.Add("Designations", Designations);
            parameters.Add("EmployeeCodes", EmployeeCodes);
            parameters.Add("DateFrom", DateFrom);
            parameters.Add("DateTo", DateTo);
            parameters.Add("AttendanceStatus", AttendanceStatus);
            parameters.Add("PresentStatus", PresentStatus);
            parameters.Add("Shifts", Shifts);
            parameters.Add("EmployeeTypeID", EmployeeTypeID);
            parameters.Add("EmployeeStatusID", EmployeeStatusID);
            parameters.Add("Gender", Gender);
            parameters.Add("Location", Location);
            parameters.Add("CA_UserID", _currentUserService.UserID);


            var connectionString = (int)enum_ServerType.Algo_HRM;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

        }

        #endregion

        public async Task<JsonResult> GetEmployeeAttendanceInfo(long EmployeeID, DateTime? DateFrom = null, DateTime? DateTo = null)
        {
            var query = new GetEmployeeAttendanceInfoQuery();
            query.EmployeeID = EmployeeID;
            query.DateFrom = (DateFrom != null && DateFrom.HasValue == true) ? DateFrom.Value : DateTime.Now.Date;
            query.DateTo = (DateTo != null && DateTo.HasValue == true) ? DateTo.Value : DateTime.Now.Date;


            if (query.DateFrom > query.DateTo)
            {
                var toDate = query.DateFrom;
                query.DateFrom = query.DateTo;
                query.DateTo = toDate;
            }
            if (DateTime.Now.AddMonths(-1) > query.DateFrom)
            {
                query.DateFrom = DateTime.Now.AddMonths(-1).Date;
            }

            var data = await Mediator.Send(query);
            return Json(data);
        }
    }
}
