using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpAttendances.Query.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.AlgoHR.Business.OutsideDuty
{
    public class OutsideDutyApplicationVM
    {
        public int OutSideTaskID { get; set; }
        [Display(Name ="Employee")]
        public int EmployeeID { get; set; }
        [Display(Name = "Employee")]
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        [Display(Name = "Date")]
        public string TaskDate { get; set; }
        [Display(Name = "Reason")]
        public string Reason { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "From")]
        public string TimeFrom { get; set; }
        [Display(Name = "To")]
        public string TimeTo { get; set; }
        [Display(Name = "Duration Type")]
        public int DutyTypeID { get; set; }
        [Display(Name = "Working Shift")]
        public string WorkingShift { get; set; }
        public bool IsApplicationForOther { get; set; } = false;
        public List<SelectListItem> DDLDutyType { get; set; }
        public List<SelectListItem> DDLEmployee { get; set; }
        //public EmployeeShiftShortInfoRM ShiftShortInfo { get; set; }
    }
}
