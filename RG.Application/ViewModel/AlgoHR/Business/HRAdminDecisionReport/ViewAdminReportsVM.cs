using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.AlgoHR.Business.HRAdminDecisionReport
{
    public class ViewAdminReportsVM
    {
        [Display(Name = "Employee Code")]
        public string EmployeeCode { get; set; }
        public string ReportType { get; set; }
        public DateTime SearchDate { get; set; }
        public int CompanyID { get; set; }
        public int DivisionID { get; set; }
        public int DepartmentID { get; set; }
        public List<SelectListItem> DDLCompany { get; set; }
        public List<SelectListItem> DDLDivision { get; set; }
        public List<SelectListItem> DDLDepartment { get; set; }

        public List<SelectListItem> ReportTypeList { get; set; }
        public List<SelectListItem> EmployeeList { get; set; }
    }
}
