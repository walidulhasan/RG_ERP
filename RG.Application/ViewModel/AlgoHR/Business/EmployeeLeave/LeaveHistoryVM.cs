using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.AlgoHR.Business.EmployeeLeave
{
    public class LeaveHistoryVM
    {
        public int EmployeeID { get; set; }
        [Display(Name = "Code")]
        public string EmployeeCode { get; set; }
        [Display(Name = "Name")]
        public string EmployeeName { get; set; }
        [Display(Name = "Company")]
        public string CompanyName { get; set; }
        [Display(Name = "Division")]
        public string DivisionName { get; set; }
        [Display(Name = "Department")]
        public string DepartmentName { get; set; }
        [Display(Name = "Section")]
        public string SectionName { get; set; }
        [Display(Name = "Designation")]
        public string Designation { get; set; }
        public bool CanViewOthersHistory { get; set; } = false;
        [Display(Name = "Appointment Date")]
        public string AppointmentDate { get; set; }
        public List<SelectListItem> DDLEmployee { get; set; }
    }
}
