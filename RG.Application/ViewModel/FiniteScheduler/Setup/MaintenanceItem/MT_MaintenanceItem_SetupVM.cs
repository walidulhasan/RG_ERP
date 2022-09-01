using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.FiniteScheduler.Setup.MaintenanceItem
{
  public  class MT_MaintenanceItem_SetupVM
    {
        public int ID { get; set; }
        [Display(Name = "Maintenance Item")]
        [Required]
        public string ItemName { get; set; }
        [Display(Name = "Category")]
        public int ItemCategoryID { get; set; }
       
        public string ItemCategoryName { get; set; }

        public List<SelectListItem> DDLItemCategory { get; set; }
    }
}
