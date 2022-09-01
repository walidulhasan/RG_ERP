using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.Application.ViewModel.FiniteScheduler.Setup.Machine
{
    public class IndexVM
    {
        [Display(Name = "Company")]
        public int? CompanyID { get; set; }

        [Display(Name = "Location")]
        public int? LocationID { get; set; }
        public List<SelectListItem> DDLCompany { get; set; }
        public List<SelectListItem> DDLLocation { get; set; }
    }
}
