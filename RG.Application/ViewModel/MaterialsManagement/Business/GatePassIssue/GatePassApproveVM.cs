using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.MaterialsManagement.Business.GatePassIssue
{
    public class GatePassApproveVM
    {
        [Display(Name = "Category")]
        public byte CategoryID { get; set; }
        [Display(Name = "Approval Type")]
        public string ApprovalType { get; set; }
        [Display(Name = "Date From")]
        public string DateFrom { get { return DateTime.Now.AddMonths(-1).ToString("dd-MMM-yyyy"); } }
        [Display(Name = "Date To")]
        public string DateTo { get { return DateTime.Now.ToString("dd-MMM-yyyy"); } }
        public List<SelectListItem> ApprovalTypeList { get; set; }
        public List<SelectListItem> CategoryList { get; set; }
    }
}
