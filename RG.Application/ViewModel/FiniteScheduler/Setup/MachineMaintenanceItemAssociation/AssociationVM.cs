using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.Application.ViewModel.FiniteScheduler.Setup.MachineMaintenanceItemAssociation
{
    public class AssociationVM
    {
        [Display(Name = "Company")]
        public int CompanyID { get; set; }
        [Display(Name = "Location")]
        public int LocationID { get; set; }
        [Display(Name = "Machine")]
        public int MachineID { get; set; }
        public List<SelectListItem> DDLMachine { get; set; }
        public List<SelectListItem> DDLLocation { get; set; }
        public List<SelectListItem> DDLCompany { get; set; }
    }
}
