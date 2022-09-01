using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Query;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpAttendances.Query;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpOutSideTask.Commands;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpOutSideTask.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Business.Vw_OutSideTask.Query;
using RG.Application.Contracts.AlgoHR.Business.Vw_OutSideTask.Query.RequestResponseModel;
using RG.Application.Contracts.AlgoHR.Setups.UserDepartmentAccess.Queries;
using RG.Application.ViewModel.AlgoHR.Business.OutsideDuty;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace RG.WEB.Areas.AlgoHR.Controllers
{
    [Area("AlgoHR")]
    [Route("AlgoHR/[controller]/[action]")]
    public class OutsideDutyController : BaseController
    {
        private readonly ICurrentUserService currentUserService;
        private readonly IDropdownService _dropdownService;
        public OutsideDutyController(ICurrentUserService _currentUserService, IDropdownService dropdownService)
        {
            currentUserService = _currentUserService;
            _dropdownService = dropdownService;
        }

        public async Task<IActionResult> MyApplications()
        {
            var empShortInfo = await Mediator.Send(new GetEmpShortInfoByCodeQuery { EmployeeCode = currentUserService.EmployeeCode, EmployeeID = currentUserService.EmployeeID });
            var model = new ApplicationSearchVM
            {
                EmployeeID = (int)empShortInfo.EmployeeID,
                EmployeeName = $"{empShortInfo.EmployeeCode} - {empShortInfo.EmployeeName}",
                EmployeeCode = empShortInfo.EmployeeCode,
                TaskDateFrom = DateTime.Now.ToString("dd-MMM-yyyy"),
                TaskDateTo = DateTime.Now.ToString("dd-MMM-yyyy"),
                DDLApplicationStatus = GetDDLApplicationStatus()
            };
            return View(model);
        }
        public async Task<IActionResult> AllApplications()
        {
            var model = new ApplicationSearchVM
            {
                DDLCompany = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLUserCompanyQuery { UserID = currentUserService.UserID, IsAll = false }), true),
                DDLDivision = _dropdownService.DefaultDDL(),
                DDLDepartment = _dropdownService.DefaultDDL(),
                DDLSection = _dropdownService.DefaultDDL(),
                DDLEmployee = _dropdownService.DefaultDDL(),
                DDLApplicationStatus = GetDDLApplicationStatus(),
                ShowApplicationForAll = true,
                TaskDateFrom = DateTime.Now.ToString("dd-MMM-yyyy"),
                TaskDateTo = DateTime.Now.ToString("dd-MMM-yyyy")
            };
            return View("MyApplications", model);
        }
        public async Task<IActionResult> Application()
        {
            var empShortInfo = await Mediator.Send(new GetEmpShortInfoByCodeQuery { EmployeeCode = currentUserService.EmployeeCode, EmployeeID = currentUserService.EmployeeID });
            var shiftShortInfo = await Mediator.Send(new GetEmployeeShiftShortInfoQuery { EmployeeID = currentUserService.EmployeeID, ShiftDate = DateTime.Now });
            var model = new OutsideDutyApplicationVM
            {
                EmployeeID = (int)empShortInfo.EmployeeID,
                EmployeeName = $"{empShortInfo.EmployeeCode} - {empShortInfo.EmployeeName}",
                EmployeeCode = empShortInfo.EmployeeCode,
                WorkingShift = shiftShortInfo.ShiftName,
                TaskDate = DateTime.Now.ToString("dd-MMM-yyyy"),
                TimeFrom = shiftShortInfo.ShiftIn.ToString("hh:mm tt"),
                TimeTo = shiftShortInfo.ShiftOut.ToString("hh:mm tt"),
                DDLDutyType = GetDDLDutyType()
            };
            return View(model);

        }
        public IActionResult ApplicationForOther()
        {
            var model = new OutsideDutyApplicationVM
            {
                IsApplicationForOther = true,
                TaskDate = DateTime.Now.ToString("dd-MMM-yyyy"),
                DDLDutyType = GetDDLDutyType()
            };
            return View("Application", model);
        }
        [HttpPost]
        public async Task<JsonResult> Application(OutsideDutyApplicationDTM model)
        {
            var result = await Mediator.Send(new SaveTbl_EmpOutSideTaskCommand { OutsideDuty = model });
            return Json(result);
        }
        private List<SelectListItem> GetDDLDutyType()
        {
            var ddl = new List<SelectListItem>
            {
                new SelectListItem { Text = "Full Day", Value = "1" },
                new SelectListItem { Text = "Partial Day", Value = "2" }
            };
            return ddl;
        }
        private List<SelectListItem> GetDDLApplicationStatus()
        {
            var ddl = new List<SelectListItem>
            {
                new SelectListItem { Text = "Applied", Value = null },
                new SelectListItem { Text = "Processing", Value = "2" },
                new SelectListItem { Text = "Approved", Value = "1" },
                new SelectListItem { Text = "Reject", Value = "0" }
            };
            return ddl;
        }
        public async Task<JsonResult> GetEmployeeShiftShortInfo(int empID, DateTime date)
        {
            var shiftShortInfo = await Mediator.Send(new GetEmployeeShiftShortInfoQuery { EmployeeID = empID, ShiftDate = date });

            var model = new OutsideDutyApplicationVM
            {
                EmployeeCode = shiftShortInfo.EmployeeCode,
                WorkingShift = shiftShortInfo.ShiftName,
                TaskDate = DateTime.Now.ToString("dd-MMM-yyyy"),
                TimeFrom = shiftShortInfo.ShiftIn.ToString("hh:mm tt"),
                TimeTo = shiftShortInfo.ShiftOut.ToString("hh:mm tt")
            };
            return Json(model);
        }
        public async Task<JsonResult> GetEmpOutsideTaskApplications(DateTime DateFrom, DateTime DateTo,int? Status, string EmployeeIDs,string Companies,string Divisions,string Departments,string Sections, DataSourceLoadOptions loadOptions)
        {
            var allCompanies = Companies!=null ? Array.ConvertAll(Companies.Split(","),int.Parse): Array.Empty<int>();
            var allEmployeeIDs = EmployeeIDs!=null? Array.ConvertAll(EmployeeIDs.Split(","), long.Parse) : Array.Empty<long>();
            var allDivisions = Divisions!=null? Array.ConvertAll(Divisions.Split(","), int.Parse) : Array.Empty<int>();
            var allDepartments = Departments != null ? Array.ConvertAll(Departments.Split(","), int.Parse) : Array.Empty<int>();
            var allSections = Sections!=null? Array.ConvertAll(Sections.Split(","), int.Parse) : Array.Empty<int>();
            
            OutSideTaskSearchQM searchModel = new (){
                Companies=allCompanies.ToList(),
                Employees=allEmployeeIDs.ToList(),
                Divisions=allDivisions.ToList(),
                Departmetns=allDepartments.ToList(),
                Sections=allSections.ToList(),
                DateFrom=DateFrom,
                DateTo=DateTo,
                ApplicationStatus=Status
            };
            var query = new GetEmpOutsideTaskApplicationsQuery
            {
                SearchModel = searchModel,
                loadOptions = loadOptions
            };
            var data = await Mediator.Send(query);
            return Json(data);
        }

    }
}
