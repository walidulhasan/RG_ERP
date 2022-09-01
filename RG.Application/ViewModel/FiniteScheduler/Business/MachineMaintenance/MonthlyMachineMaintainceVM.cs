using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.FiniteScheduler.Business.MachineMaintenance
{
  public  class MonthlyMachineMaintainceVM
    {

        [Display(Name = "Company")]
        public int CompanyID { get; set; }
        [Display(Name = "Location")]
        public int LocationID { get; set; }
        [Display(Name = "Month")]
        public int MonthID { get; set; }
        [Display(Name = "Year")]
        public int YearID { get; set; }
        public List<SelectListItem> DDLCompany { get; set; }
        public List<SelectListItem> DDLLocation { get; set; }
        public List<SelectListItem> DDLMonth { get; set; }
        public List<SelectListItem> DDLYear { get; set; }
    }
}
