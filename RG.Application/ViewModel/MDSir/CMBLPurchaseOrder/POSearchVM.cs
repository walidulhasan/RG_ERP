using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.MDSir.CMBLPurchaseOrder
{
    public class POSearchVM
    {
        [Display(Name ="Company")]
        public int CompanyID { get; set; }
        public List<SelectListItem> DDLCompany { get; set; }
        [Display(Name ="PO No")]
        public int POID { get; set; }
        public List<SelectListItem> DDLPO { get; set; }
    }
}
