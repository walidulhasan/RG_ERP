using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.AlgoHR.Business.OutsideDuty
{
   public class ApplicationSearchVM
    {
        [Display(Name = "Employee")]
        public int EmployeeID { get; set; }
        [Display(Name = "Employee")]
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        [Display(Name = "From")]
        public string TaskDateFrom { get; set; }
        [Display(Name = "To")]
        public string TaskDateTo { get; set; }
        public bool ShowApplicationForAll { get; set; } = false;
        public List<SelectListItem> DDLDutyType { get; set; }
        public List<SelectListItem> DDLEmployee { get; set; }
        public int CompanyID { get; set; }
        public List<SelectListItem> DDLCompany { get; set; }
        public int DivisionID { get; set; }
        public List<SelectListItem> DDLDivision { get; set; }
        public int DepartmentID { get; set; }
        public List<SelectListItem> DDLDepartment { get; set; }

        public int SectionID { get; set; }
        public List<SelectListItem> DDLSection { get; set; }
        [Display(Name ="Status")]
        public string ApplicationStatus { get; set; }
        public List<SelectListItem> DDLApplicationStatus { get; set; }


    }
}
