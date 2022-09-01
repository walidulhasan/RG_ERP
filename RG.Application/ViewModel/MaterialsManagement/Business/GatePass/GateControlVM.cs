using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.Application.ViewModel.MaterialsManagement.Business.GatePass
{
    public class GateControlVM
    {
        [Display(Name = "Category")]
        public int CategoryID { get; set; }
        [Display(Name = "Status")]
        public int StatusID { get; set; }
        [Display(Name = "Start Date")]
        public string StartDate { get; set; }
        [Display(Name = "End Date")]
        public string EndDate { get; set; }
        [Display(Name = "Category PassNo")]
        public string CategoryPassNo { get; set; }
        public List<SelectListItem> CategoryList { get; set; }
        public List<SelectListItem> StatusList { get; set; }
    }
}
