using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.Application.ViewModel.Maxco.Business.OrderScheduling
{
    public class OrderSchedulingMasterVM
    {
        public int OrderID { get; set; }
        public string FlgForAction { get; set; }
        public List<SelectListItem> DDLOrders { get; set; }
        public List<KnittingSchedulingVM> KnittingScheduling { get; set; }
        public List<DyeingSchedulingVM> DyeingScheduling { get; set; }
        public List<CuttingSchedulingVM> CuttingScheduling { get; set; }
        public List<CuttingSchedulingVM> SewingScheduling { get { return CuttingScheduling; } }

        //Modal OrderKnittingPlan
        [Display(Name ="Schedule Date")]
        public string ScheduleDate { get; set; }
        public decimal Quantity { get; set; }
    }
}
