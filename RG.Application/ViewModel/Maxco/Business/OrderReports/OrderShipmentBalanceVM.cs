using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.Maxco.Business.OrderReports
{
    public class OrderShipmentBalanceVM
    {
        [Display(Name ="Buyer")]
        public int BuyerID { get; set; }
        [Display(Name = "Order No")]
        public int OrderID { get; set; }
        [Display(Name = "Date From")]
        public string DateFrom { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("dd-MMM-yyyy");
        [Display(Name = "Date To")]
        public string DateTo { get; set; } = DateTime.Now.ToString("dd-MMM-yyyy");
        public List<SelectListItem> DDLBuyer { get; set; }
        public List<SelectListItem> DDLOrder { get; set; }
    }
}
