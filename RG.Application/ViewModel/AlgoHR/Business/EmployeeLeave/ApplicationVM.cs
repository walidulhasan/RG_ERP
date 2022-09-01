using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.Application.ViewModel.AlgoHR.Business.EmployeeLeave
{
    public class ApplicationVM
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
        [Display(Name = "Appointment Date")]
        public string AppointmentDate { get; set; }
        public bool CanApplyForOthers { get; set; } = false;
        [Display(Name = "Leave Type")]
        public int LeaveID { get; set; }
        [Display(Name = "Leave From")]
        public string DateFrom { get; set; }
        [Display(Name = "Leave to")]
        public string DateTo { get; set; }
        [Display(Name = "Days")]
        public int TotalDay { get; set; }
        [Display(Name = "Leave Reason")]
        public string LeaveReason { get; set; }
        [Display(Name = "Leave Address")]
        public string LeaveAddress { get; set; }


        [Display(Name = "Leave Date")]
        public string ShortLeaveDate { get; set; }
        [Display(Name = "From")]
        public string TimeFrom { get; set; }
        [Display(Name = "To")]
        public string TimeTo { get; set; }

        [Display(Name = "Will Return To Office")]
        public bool Returnable { get; set; }
        public int DocumentType { get; set; }
        public List<SelectListItem> DDLDocumentType { get; set; }
        public  DateTime? LastSalaryDate { get; set; }
        public List<SelectListItem> DDLEmployee { get; set; }
        public List<SelectListItem> DDLLeaves { get; set; }
    }
}
