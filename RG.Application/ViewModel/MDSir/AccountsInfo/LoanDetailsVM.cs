using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.MDSir.AccountsInfo
{
    public class LoanDetailsVM
    {
        public int UserID { get; set; }
        public int Company { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        [Display(Name = "Date From")]
        public string DateFrom { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("dd-MMM-yyyy");
        [Display(Name = "Date To")]
        public string DateTo { get; set; }= DateTime.Now.ToString("dd-MMM-yyyy");
        public List<SelectListItem> DDLCompany { get; set; }
        public List<SelectListItem> DDLMonths { get; set; }
        public List<SelectListItem> DDLYears { get; set; }
    }
}
