using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.Embro.Business.GeneralLedgers
{
    public class GeneralLedgerTrailBalanceVM
    {

        public int CompanyID { get; set; }
        public List<SelectListItem> DDLCompany { get; set; }

        public int BusinessID { get; set; }
        public List<SelectListItem> DDLBusiness { get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public string DateFromST { get { return DateFrom.ToString("dd-MMM-yyyy"); } }
        public string DateToST { get { return DateTo.ToString("dd-MMM-yyyy"); } }

        [Display(Name = "Account Level")]
        public int AccountLevel { get; set; }
        public List<SelectListItem> DDLAccountLevel { get; set; }
        [Display(Name = "Select By Cost Center")]
        public int SelectByCostCenter { get; set; }
        public List<SelectListItem> DDLSelectByCostCenter { get; set; }
        [Display(Name = "Select With Detail")]
        public int SelectWithDetail { get; set; }
        public List<SelectListItem> DDLSelectWithDetail { get; set; }

        [Display(Name = "Report Type")]
        public int ReportGroup { get; set; }
        public List<SelectListItem> DDLReportGroup { get; set; }

        [Display(Name = "Voucher Status")]
        public int VoucherPosted { get; set; }
        public List<SelectListItem> DDLVoucherPosted { get; set; }

        [Display(Name = "Exclude Zero Balance in Current Activity Duration.")]
        public bool IsExcludeZeroBalance { get; set; }

        public string ExecutionType { get; set; }
        public List<SelectListItem> DDLExecutionType { get; set; }

    }
}
