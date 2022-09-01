using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.EMS.Business.ShipmentReport
{
    public class OrderShipmentDetailsVM
    {
       
        [Display(Name = "Company")]
        [Required(ErrorMessage = "Company Name is required")]
        public int CompanyID { get; set; }
        [Display(Name = "Buyer Name")]
        [Required(ErrorMessage = "Buyer Name is required")]
        public int BuyerID { get; set; }
        [Display(Name = "Order")]
        [Required(ErrorMessage = "Order is required")]
        public long OrderID { get; set; }
        [Display(Name = "Date From")]        
        public string DateFrom{ get; set; }
        [Display(Name = "Date To")]
        public string DateTo { get; set; }
        public List<SelectListItem> DDLCompany { get; set; }
        public List<SelectListItem> DDLBuyer { get; set; }
       
    }
}
