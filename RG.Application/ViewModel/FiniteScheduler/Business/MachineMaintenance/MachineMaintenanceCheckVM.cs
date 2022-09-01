using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.FiniteScheduler.Business.MachineMaintenance
{
    public class MachineMaintenanceCheckVM
    {
        public int MasterID { get; set; }
        [Display(Name = "Company")]
        public int? CompanyID { get; set; }

        [Display(Name = "Location")]
        public int? LocationID { get; set; }
        [Required]
        [Display(Name = "Machine")]
        public int MachineID { get; set; }
        [Required]
        [Display(Name = "Schedule Date")]
        public string ScheduleDate { get; set; }
        [Display(Name = "Check Date")]
        public string CheckDate { get; set; }
        //[Required]
        //[Display(Name = "Next Preventative Date")]        
        //public DateTime NextPreventativeDate { get; set; }
        public string MechanicalTaskTeamMember { get; set; }
        public string MechanicalSupervisor { get; set; }
        public string MechanicalWorkerComments { get; set; }
        public string ElectricalTaskTeamMember { get; set; }
        public string ElectricalSupervisor { get; set; }
        public string ElectricalWorkerComments { get; set; }
        public List<SelectListItem> DDLMachine { get; set; }
        public List<SelectListItem> DDLCompany { get; set; }
        public List<SelectListItem> DDLLocation { get; set; }
        public List<SelectListItem> DDLScheduleDates { get; set; }
    }
}
