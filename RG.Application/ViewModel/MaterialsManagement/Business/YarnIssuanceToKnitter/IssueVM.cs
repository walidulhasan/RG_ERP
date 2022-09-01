using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.MaterialsManagement.Business.YarnIssuanceToKnitter
{
    public class IssueVM
    {
        [Display(Name ="Order No")]
        public long OrderID { get; set; }
        [Display(Name = "KRS No")]
        public long KRSID { get; set; }
        [Display(Name = "YKNC No")]
        public long YKNCID { get; set; }
        public List<SelectListItem> DDLOrder { get; set; }
        public List<SelectListItem> DDLKRS { get; set; }
        public List<SelectListItem> DDLYKNC { get; set; }
    }
}
