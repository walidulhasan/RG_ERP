using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.AlgoHR.Business.HRAdminDecisionReport
{
    public class EmpInfoSearchVM
    {
        [Display(Name = "Comapny")]
        public int CompanyID { get; set; }
        [Display(Name = "Division")]
        public int DivisionID { get; set; }
        [Display(Name = "Department")]
        public int DepartmentID { get; set; }
        [Display(Name = "Section")]
        public int SectionID { get; set; }
        [Display(Name = "Designation")]
        public int DesignationID { get; set; }

        [Display(Name = "Employee Code")]
        public string EmployeeCode { get; set; }
        [Display(Name = "Date From")]
        public string DateFrom { get; set; }

        [Display(Name = "Date To")]
        public string DateTo { get; set; }
        [Display(Name = "Attendance Status")]
        public int StatusID { get; set; }
        [Display(Name = "Present Status")]
        public int PresentStatusID { get; set; }
        public int ShiftID { get; set; }
        public List<SelectListItem> DDLStatus { get; set; }
        public List<SelectListItem> DDLPresentStatus { get; set; }
        public List<SelectListItem> DDLCompany { get; set; }
        public List<SelectListItem> DDLDesignation { get; set; }
        public List<SelectListItem> DDLDivision { get; set; }
        public List<SelectListItem> DDLDepartment { get; set; }
        public List<SelectListItem> DDLSection { get; set; }
        public List<SelectListItem> DDLShift { get; set; }
        public List<SelectListItem> EmployeeList { get; set; }

    }
}
