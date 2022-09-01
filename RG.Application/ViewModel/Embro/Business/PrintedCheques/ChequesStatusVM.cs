using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.Embro.Business.PrintedCheques
{
    public class ChequesStatusVM
    {
        [Display(Name ="Bank")]
        public int BankID { get; set; }
        [Display(Name = "Account")]
        public int AccountID { get; set; }
        [Display(Name = "From")]
        public string DateFrom { get; set; }
        [Display(Name = "To")]
        public string DateTo { get; set; }
        [Display(Name = "Status")]
        public int StatusID { get; set; }
        [Display(Name = "Updated Status")]
        public int UpdatedStatusID { get; set; }
        [Display(Name = "Paid To")]
        public string PaidTo { get; set; }
        [Display(Name = "Clearing Date")]
        public string ClearingDate { get; set; }
        public List<SelectListItem> DDLBank { get; set; }
        public List<SelectListItem> DDLAccount { get; set; }
        public List<SelectListItem> DDLStatus { get; set; }
        public List<SelectListItem> DDLPaidTo { get; set; }
    }
}
