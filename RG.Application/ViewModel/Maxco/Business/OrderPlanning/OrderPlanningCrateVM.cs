using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.Application.ViewModel.Maxco.Business.OrderPlanning
{
    public class OrderPlanningCrateVM
    {
        public OrderPlanningCrateVM()
        {
            
        }
        public int OrderID { get; set; }
        [Display(Name ="Order Date")]
        public string POReceivedDate { get; set; }
        public int PlanID { get; set; }
        public int VersionID { get; set; }
        public List<SelectListItem> DDLOrders { get; set; }
 
    }

}
