using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.MDSir.ExportDocument
{
    public class LCMaturityRealizationVM
    {
        [Display(Name = "Filter Type")]
        public int FilterTypeID { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        [Display(Name = "Fund Type")]
        public int FundTypeID { get; set; }
        [Display(Name = "Company")]
        public int CompanyID { get; set; }
        [Display(Name = "Date From")]
        public string DateFrom { get; set; }
        [Display(Name = "Date To")]
        public string DateTo { get; set; }
        public List<SelectListItem> DDLFilterType { get; set; }
        public List<SelectListItem> DDLMonth { get; set; }
        public List<SelectListItem> DDLYear { get; set; }
        public List<SelectListItem> DDLFundType { get; set; }
        public List<SelectListItem> DDLCompany { get; set; }
    }
}
