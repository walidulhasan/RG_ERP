using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.FiniteScheduler.Setup.MTMachineSetup
{
  public  class MT_Machine_SetupVM
    {
        public int MachineID { get; set; }
        [Display(Name = "Machine Name")]
        [Required]
        public string MachineName { get; set; }
        [Display(Name = "Machine Code ")]
        [Required]
        public string MachineCode { get; set; }
        [Display(Name = "Company")]
        public int CompanyID { get; set; }
        [Display(Name = "Location")]
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        [Display(Name = "Department")]
        public int? DepartmentID { get; set; }
        
        [Display(Name ="Machine Group")]
        public int MachineGroupID { get; set; }
        public string MachineGroup { get; set; }

        [Display(Name = "Min. Maintaince Duration Days")]
        public int? MinMaintainceDurationDays { get; set; }
        public int CreatedBy { get; set; }
        public List<SelectListItem> DDLCompany { get; set; }
        public List<SelectListItem> DDLLocation { get; set; }
        public List<SelectListItem> DDLMinMaintainceDurationDays { get; set; }
        public List<SelectListItem> DDLMachineGroup { get; set; }
        //public string CheckedDateStr { get { return CheckedDate == null ? "" : CheckedDate.Value.ToString("dd-MMM-yyyy"); } }
        //public string NextCheckDateStr { get { return NextCheckDate == null ? "" : NextCheckDate.Value.ToString("dd-MMM-yyyy"); } }
    }
}
