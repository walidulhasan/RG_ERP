using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Common.Models;
using RG.Application.Common.Utilities;
using RG.Application.Constants;
using RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Query;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpLeavess.Commands.Update;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpLeavess.Query;
using RG.Application.Contracts.AlgoHR.Business.Tbl_Payroll_Masters.Query;
using RG.Application.Contracts.AlgoHR.Setups.Tbl_Leavess.Query;
using RG.Application.Contracts.AlgoHR.Setups.UploadedDocumentTypes.Queries;
using RG.Application.Contracts.AlgoHR.Tbl_EmpLeavess.Commands.Create;
using RG.Application.Contracts.AlgoHR.Tbl_EmpLeavess.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Tbl_EmpLeavess.Query.RequestResponseModel;
using RG.Application.Contracts.Embro.CompanyInfos.Queries;
using RG.Application.Enums;
using RG.Application.ViewModel.AlgoHR.Business.EmployeeLeave;
using RG.Application.ViewModel.AlgoHR.Business.EmployeeLeaveCancel;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.AlgoHR.Controllers
{
    [Area("AlgoHR")]
    [Route("AlgoHR/[controller]/[action]")]
    public class EmployeeLeaveController : BaseController
    {
        private readonly IDropdownService _dropdownService;
        private readonly ICurrentUserService currentUserService;

        public EmployeeLeaveController(IDropdownService dropdownService, ICurrentUserService _currentUserService)
        {
            _dropdownService = dropdownService;
            currentUserService = _currentUserService;
        }
        public async Task<IActionResult> Index()
        {
            var model = new IndexLeaveListVM()
            {
                DDLLeaveStatus = GetDDLApplicationStatus(),
                DDLLeaves = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLLeavesQuery { }), true),
                DateFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("dd-MMM-yyyy"),
                DateTo = DateTime.Now.ToString("dd-MMM-yyyy"),
                DDLCompany = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), true),
                DDLOfficeDivision = _dropdownService.DefaultDDL(),
                DDLDepartment = _dropdownService.DefaultDDL(),
            };
            return View(model);
        }
        public async Task<IActionResult> Application()
        {
            var model = new ApplicationVM()
            {
                EmployeeCode = currentUserService.EmployeeCode,
                DDLLeaves = _dropdownService.DefaultDDL(),
                DDLDocumentType = await Mediator.Send(new GetDDLUploadedDocumentTypeQuery { ModuleName = ApprovalModules.LeaveApplication }),
                LastSalaryDate = await Mediator.Send(new GetLastSalaryDateQuery { })
            };
            var isSuperAdmin = User.Claims.FirstOrDefault(x=>x.Type==SessionKey.IsSuperAdmin)?.Value;
            var isLeaveSpecialEntry = User.Claims.FirstOrDefault(x => x.Type == UserClaimsCC.LeaveSpecialEntry)?.Value;

            if ((isSuperAdmin!=null && isSuperAdmin == "True")||(isLeaveSpecialEntry!=null && isLeaveSpecialEntry=="1"))
            {
                model.LastSalaryDate = DateTime.Now.AddMonths(-2);
            }
            return View(model);
        }
        public async Task<IActionResult> ApplicationForOthers()
        {
            var model = new ApplicationVM()
            {
                CanApplyForOthers = true,
                DDLLeaves = _dropdownService.DefaultDDL(),
                DDLDocumentType = await Mediator.Send(new GetDDLUploadedDocumentTypeQuery { ModuleName = ApprovalModules.LeaveApplication }),
                LastSalaryDate = await Mediator.Send(new GetLastSalaryDateQuery { })
            };
            var isSuperAdmin = User.Claims.FirstOrDefault(x => x.Type == SessionKey.IsSuperAdmin)?.Value;

            var isLeaveSpecialEntry = User.Claims.FirstOrDefault(x => x.Type == UserClaimsCC.LeaveSpecialEntry)?.Value;

            if ((isSuperAdmin != null && isSuperAdmin == "True") || (isLeaveSpecialEntry != null && isLeaveSpecialEntry == "1"))
            {
                model.LastSalaryDate = DateTime.Now.AddMonths(-2);
            }
            return View("Application", model);
        }
        public IActionResult LeaveHistory()
        {
            var model = new LeaveHistoryVM()
            {
                CanViewOthersHistory = true
            };
            return View(model);
        }
        public IActionResult IndividualLeaveHistory()
        {
            var model = new LeaveHistoryVM()
            {
                EmployeeCode = currentUserService.EmployeeCode
            };
            return View("LeaveHistory", model);
        }
        public ActionResult CallViewComponents(int employeeID, int leaveTypeID, bool? leaveStatus, bool leaveStatusIndependent = true)
        {
            var viewComponentName = "LeaveHistoryDetail";
            LeaveHistoryDetailQM queryModel = new()
            {
                EmployeeID = employeeID,
                LeaveTypeID = leaveTypeID,
                LeaveStatusIndependent = leaveStatusIndependent,
                LeaveStatus = leaveStatus,
                ShowEmployeeCode = false,
                ShowEmployeeName = false,
                ShowCompanyName = false,
                ShowDivisionName = false,
                ShowDepartmentName = false,
                ShowSectionName = false,
                ShowDesignationName = false,
                ShowAppointmentDate = false,
            };

            return ViewComponent(viewComponentName, queryModel);
        }
        [HttpPost]
        public async Task<IActionResult> Application(EmpLeaveDTM empLeave)
        {
            var data = await Mediator.Send(new EmpLeaveCreateCommand { EmpLeave = empLeave });
            return Json(data);
        }
        public async Task<JsonResult> GetEmployeeShortInfo(string employeeCode, long? employeeID = 0)
        {
            var empShortInfo = await Mediator.Send(new GetEmpShortInfoByCodeQuery { EmployeeCode = employeeCode, EmployeeID = employeeID });
            return Json(empShortInfo);
        }
        public async Task<JsonResult> GetDDLCustomEmpLeaves(int employeeID, string employeeCode)
        {
            var customLeaveList = await Mediator.Send(new GetDDLCustomEmpLeavesQuery { EmployeeID = employeeID, EmployeeCode = employeeCode });

            
            return Json(customLeaveList);
        }

        public async Task<JsonResult> RemoveLeaveApplication(int leaveID,int leaveTypeID)
        {
            var data = await Mediator.Send(new EmpLeaveDeleteCommand { ID = leaveID, LeaveTypeID= leaveTypeID });
            return Json(data);
        }
        #region Report
        public async Task<IActionResult> LeaveApplicationFormReport(int applicationID, int employeeID = 0, int leaveHistoryYear = 0, string ReportFormat = "PDF")
        {
            string reportName = $"/{ReportFolder.AlgoHRFolder}/LeaveApplicationForm";

            IDictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("ApplicationID", applicationID);
            parameters.Add("EmployeeID", employeeID);
            parameters.Add("LeaveHistoryYear", leaveHistoryYear);


            var connectionString = (int)enum_ServerType.Algo_HRM;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

        }

        #endregion

        private List<SelectListItem> GetDDLApplicationStatus()
        {
            var ddl = new List<SelectListItem>
            { 
                new SelectListItem { Text = "All", Value = "-1" },
                new SelectListItem { Text = "Processing", Value = "" },
                new SelectListItem { Text = "Approved", Value = "1" },
                new SelectListItem { Text = "Reject", Value = "0" }
            };
            return ddl;
        }
        
        public async Task<JsonResult> SearchedLeaveList(DataSourceLoadOptions loadOptions,int leaveID, string leaveStatus, DateTime dateFrom, DateTime dateTo, int companyID, int divisionID, int departmentID)
        {
            var _data = await Mediator.Send(new GetSearchedLeaveListQuery { LeaveID = leaveID, leaveStatus = leaveStatus, DateFrom = dateFrom, DateTo = dateTo, CompanyID = companyID, DivisionID = divisionID, DepartmentID = departmentID });
            var data = DataSourceLoader.Load(_data,loadOptions);
            return Json(data);
        }
        public async Task<JsonResult> GetEmpLeaveInfo(int leaveApplicationID)
        {
            var data = await Mediator.Send(new GetEmpLeaveInfoQuery {id=leaveApplicationID});
            return Json(data);
        }
        [HttpPost]
        public async Task<IActionResult> LeaveApplicationCancel(EmployeeLeaveCancelVM employeeLeaveCancelVM)
        {
            var data = await Mediator.Send(new LeaveApplicationApprovedCancelAutoCommand { employeeLeaveCancelVM = employeeLeaveCancelVM });
            return Json(data);
        }
        [HttpPost]
        public async Task<IActionResult> LeaveApplicationAdjust(EmployeeLeaveCancelVM leaveAdjust)
        {
            var data = await Mediator.Send(new ApprovedLeaveApplicationAdjustCommand { LeaveAdjust = leaveAdjust });
            return Json(data);
        }

        
        #region All Leave List
        public async Task<IActionResult> AllLeaveList()
        {
            return View();
        }

        public async Task<IActionResult> GetDDLComplimentaryLeave(int empID)
        {
            var data = _dropdownService.RenderDDL( await Mediator.Send(new GetDDLComplimentaryLeaveQuery { EmployeeID = empID }),true);
            return Json(data);
        }

        #endregion
    }
}
