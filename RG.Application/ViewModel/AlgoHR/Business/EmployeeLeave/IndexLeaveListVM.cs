using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.AlgoHR.Business.EmployeeLeave
{
    public class IndexLeaveListVM
    {
        [Display(Name = "Type")]
        public int LeaveID { get; set; }
        [Display(Name = "Leave Status")]
        public int? LeaveStatus { get; set; }
        [Display(Name = "Date From")]
        public string DateFrom { get; set; }
        [Display(Name = "Date To")]
        public string DateTo { get; set; }
        [Display(Name = "Company")]
        public int CompanyID { get; set; }
        [Display(Name = "Division")]
        public int OfficeDivisionID { get; set; }
        [Display(Name = "Department")]
        public int DepartmentID { get; set; }
        public List<SelectListItem> DDLLeaves { get; set; }
        public List<SelectListItem> DDLLeaveStatus { get; set; }
        public List<SelectListItem> DDLCompany { get; set; }
        public List<SelectListItem> DDLOfficeDivision { get; set; }
        public List<SelectListItem> DDLDepartment { get; set; }
    }
}
