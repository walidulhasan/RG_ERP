using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.AlgoHR.Business.EmployeeAttendance
{
    public class LateVM
    {
        [Display(Name="Company")]
        public int CompanyID { get; set; }
        [Display(Name = "Division")]
        public int OfficeDivisionID { get; set; }
        [Display(Name = "Department")]
        public int DepartmentID { get; set; }
        [Display(Name = "Section")]
        public int SectionID { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public List<SelectListItem> DDLCompany { get; set; }
        public List<SelectListItem> DDLOfficeDivision { get; set; }
        public List<SelectListItem> DDLDepartment { get; set; }
        public List<SelectListItem> DDLSection { get; set; }
        public List<SelectListItem> DDLYear { get; set; }
        public List<SelectListItem> DDLMonth { get; set; }
    }
}
