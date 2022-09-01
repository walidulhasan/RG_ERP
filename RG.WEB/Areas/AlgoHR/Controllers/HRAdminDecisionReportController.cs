using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.Utilities;
using RG.Application.Constants;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpAttendances.Query;
using RG.Application.Contracts.AlgoHR.Setups.Tbl_Company.Query;
using RG.Application.Contracts.Embro.CompanyInfos.Queries;
using RG.Application.Enums;
using RG.Application.ViewModel.AlgoHR.Business.HRAdminDecisionReport;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.Areas.AlgoHR.Controllers
{
    [Area("AlgoHR")]
    [Route("AlgoHR/[controller]/[action]")]
    public class HRAdminDecisionReportController : BaseController
    {
        private readonly IDropdownService _dropdownService;

        public HRAdminDecisionReportController(IDropdownService dropdownService)
        {
            _dropdownService = dropdownService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ViewReports()
        {
            var dropItem = new List<SelectListItem>()
            {
               new SelectListItem{Text="Appointment Letter(Garments)", Value="AppointmentLetterGarments"},
               new SelectListItem{Text="Appointment Letter(Textile)", Value="AppointmentLetterTextile"},
               new SelectListItem{Text="Appointment Letter(MSL)", Value="AppointmentLetterMSL"},

               new SelectListItem{Text="1st Lefty Letter(Worker)", Value="WorkerFirstLeftyLetter"},
               new SelectListItem{Text="2nd Lefty Letter(Worker)", Value="WorkerSecondLeftyLetter"},
               new SelectListItem{Text="Final Lefty Letter(Worker)", Value="WorkerFinalLeftyLetter"},

               new SelectListItem{Text="1st Lefty Letter(Staff)", Value="StaffFirstLeftyLetter"},
               new SelectListItem{Text="2nd Lefty Letter(Staff)", Value="StaffSecondLeftyLetter"},
               new SelectListItem{Text="Final Lefty Letter(Staff)", Value="StaffFinalLeftyLetter"},

                new SelectListItem{Text="Probation Confirmation Letter(Worker)", Value="WorkerProbationConfirmationLetter"},

                new SelectListItem{Text="Probation Extension Letter(Worker)", Value="WorkerProbationExtensionLetter"},
                new SelectListItem{Text="Promotion Letter(Worker)", Value="WorkerPromotionLetter"},

                new SelectListItem{Text="Leave Application Letter(Worker)", Value="LeaveApplicationLetterforWorker"},
                new SelectListItem{Text="Increment Letter(Worker)", Value="IncrementLetterforWorker"},

                new SelectListItem{Text="Nominee Form(Worker)", Value="NomineeFormforWorker"},
                new SelectListItem{Text="Nominee Form(Stuff)", Value="NomineeFormforStaff"},

                 new SelectListItem{Text="Capability Testimonial", Value="AgeCapabilityTestimonial"}
            };
            var model = new ViewAdminReportsVM();
            model.ReportTypeList = _dropdownService.RenderDDL(dropItem, true);

            model.DDLCompany = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), true);
            model.DDLDivision = _dropdownService.DefaultDDL();
            model.DDLDepartment = _dropdownService.DefaultDDL();

            return View(model);
        }

        public async Task<IActionResult> EmployeeAdminReportsPrint(int EmployeeID, string AbsentFromDate, string ReportType, string ReportFormat)
        {
            string reportName = "";
            IDictionary<string, object> parameters = new Dictionary<string, object>();
            if (ReportType == "AppointmentLetterGarments")
            {
                reportName = "AppoinmentLetterForGarments";
                parameters.Add("EmployeeID", EmployeeID);
            }
            else if (ReportType == "AppointmentLetterTextile")
            {
                reportName = "AppoinmentLetterForTextile";
                parameters.Add("EmployeeID", EmployeeID);
            }
            else if (ReportType == "AppointmentLetterMSL")
            {
                reportName = "AppoinmentLetterForMSL";
                parameters.Add("EmployeeID", EmployeeID);
            }

            else if (ReportType == "WorkerFirstLeftyLetter")
            {
                reportName = "LeftyLetterForWorker_FirstLetters";
                parameters.Add("EmployeeID", EmployeeID);
                parameters.Add("AbsentFromDate", Convert.ToDateTime(AbsentFromDate));
            }
            else if (ReportType == "WorkerSecondLeftyLetter")
            {
                reportName = "LeftyLetterForWorker_SecondLetters";
                parameters.Add("EmployeeID", EmployeeID);
                parameters.Add("AbsentFromDate", Convert.ToDateTime(AbsentFromDate));
            }
            else if (ReportType == "WorkerFinalLeftyLetter")
            {
                reportName = "LeftyLetterForWorker_FinalLetters";
                parameters.Add("EmployeeID", EmployeeID);
                parameters.Add("AbsentFromDate", Convert.ToDateTime(AbsentFromDate));
            }

            else if (ReportType == "StaffFirstLeftyLetter")
            {
                reportName = "LeftyLetterStaff_FirstLatter";
                parameters.Add("EmployeeID", EmployeeID);
                parameters.Add("AbsentFromDate", Convert.ToDateTime(AbsentFromDate));
            }
            else if (ReportType == "StaffSecondLeftyLetter")
            {
                reportName = "LeftyLetterStaff_SecondLetter";
                parameters.Add("EmployeeID", EmployeeID);
                parameters.Add("AbsentFromDate", Convert.ToDateTime(AbsentFromDate));
            }
            else if (ReportType == "StaffFinalLeftyLetter")
            {
                reportName = "LeftyLetterStaff_FinalLetter";
                parameters.Add("EmployeeID", EmployeeID);
                parameters.Add("AbsentFromDate", Convert.ToDateTime(AbsentFromDate));
            }

            else if (ReportType == "WorkerProbationConfirmationLetter")
            {
                reportName = "ProbationConfirmationLetterforWorker";
                parameters.Add("EmployeeID", EmployeeID);
            }
            else if (ReportType == "WorkerProbationExtensionLetter")
            {
                reportName = "ProbationExtensionLetterforWorker";
                parameters.Add("EmployeeID", EmployeeID);
            }
            else if (ReportType == "WorkerPromotionLetter")
            {
                reportName = "PromotionLetterForWorker";
                parameters.Add("EmployeeID", EmployeeID);
            }
            else if (ReportType == "LeaveApplicationLetterforWorker")
            {
                reportName = "LeaveApplicationLetter";
                parameters.Add("EmployeeID", EmployeeID);
            }
            else if (ReportType == "IncrementLetterforWorker")
            {
                reportName = "IncrementLetterForWorker";
                parameters.Add("EmployeeID", EmployeeID);
            }

            else if (ReportType == "NomineeFormforWorker")
            {
                reportName = "NomineeFormForWorker";
                // parameters.Add("EmployeeID", EmployeeID);
            }
            else if (ReportType == "NomineeFormforStaff")
            {
                reportName = "NomineeFormForStaff";
                //parameters.Add("EmployeeID", EmployeeID);
            }
            else if (ReportType == "AgeCapabilityTestimonial")
            {
                reportName = "AgeAndCapabilityTestimonial";
                parameters.Add("EmployeeID", EmployeeID);
            }
            var _reportName = $"/{ReportFolder.AlgoHRFolder}/{reportName}";
            int connectionString = (int)enum_ServerType.Algo_HRM;
            return await PrintSSRSReport(_reportName, parameters, ReportFormat, connectionString);

        }

        public async Task<JsonResult> GetLeftyEmployeeList(string ReportType, DateTime DateTo, string CompanyID, string DivisionID, string DepartmentID)
        {
            GetLeftyEmployeeListQuery queryModel = new GetLeftyEmployeeListQuery();

            queryModel.NoOfAbsentDays = 0;
            queryModel.IsStaff = false;
            if (ReportType == "WorkerFirstLeftyLetter")
            {
                queryModel.NoOfAbsentDays = 10;
            }
            else if (ReportType == "WorkerSecondLeftyLetter")
            {
                queryModel.NoOfAbsentDays = 20;
            }
            else if (ReportType == "WorkerFinalLeftyLetter")
            {
                queryModel.NoOfAbsentDays = 27;
            }

            else if (ReportType == "StaffFirstLeftyLetter")
            {
                queryModel.NoOfAbsentDays = 10;
                queryModel.IsStaff = true;
            }
            else if (ReportType == "StaffSecondLeftyLetter")
            {
                queryModel.NoOfAbsentDays = 20;
                queryModel.IsStaff = true;
            }
            else if (ReportType == "StaffFinalLeftyLetter")
            {
                queryModel.NoOfAbsentDays = 27;
                queryModel.IsStaff = true;
            }
            queryModel.DateTo = DateTo;
            queryModel.CompanyID = CompanyID;
            queryModel.DivisionID = DivisionID;
            queryModel.DepartmentID = DepartmentID;
            var data = await Mediator.Send(queryModel);

            return Json(data);
        }

        public async Task<IActionResult> EmployeeInformation()
        {
            var dropItem = new EmpInfoSearchVM()
            {
                DDLCompany = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLCompanyInfoQuery()), true),
                DDLDivision = _dropdownService.DefaultDDL(),
                DDLDepartment = _dropdownService.DefaultDDL(),
                DDLSection = _dropdownService.DefaultDDL(),
                DDLDesignation = _dropdownService.DefaultDDL()
            };
            return View(dropItem);
        }
        public async Task<IActionResult> EmployeeInfoReportPrint(string Companies, string Divisions, string Departments, string Sections, string Designations, string EmployeeCodes, string ReportFormat)
        {
            string reportName = $"/{ReportFolder.AlgoHRFolder}/rpt_ActiveEmployeeList";
            Companies = string.IsNullOrEmpty(Companies)? "183,20183": Companies;
            
                var compParm = new GetEmbroToHrCompanyQuery();
            var embroComapyId = ListToString.StringToIntList<int>(Companies);
                if (embroComapyId.Count > 1)
                { 
                        compParm.EmbroCountryIDList.AddRange(embroComapyId); 
                }
                else
                {
                    compParm.EmbroCountryID = embroComapyId[0];
                }
            var hrCompany = await Mediator.Send(compParm);
            var hrCompanyStringArray = ListToString.IntListToString(hrCompany);
             
            IDictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("Companies", hrCompanyStringArray);
            parameters.Add("Divisions", Divisions);
            parameters.Add("Departments", Departments);
            parameters.Add("Sections", Sections);
            parameters.Add("Designations", Designations);
            parameters.Add("EmployeeCodes", EmployeeCodes);
            int connectionString = (int)enum_ServerType.Algo_HRM;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);
        }
    }
}
