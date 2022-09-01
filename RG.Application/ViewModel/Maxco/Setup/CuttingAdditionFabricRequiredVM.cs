using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.Maxco.Setup
{
    public class CuttingAdditionFabricRequiredVM
    {
        [Display(Name = "Buyer Name")]
        [Required(ErrorMessage = "Buyer Name is required")]
        public int BuyerID { get; set; }
        public int ID { get; set; }
        [Display(Name = "Order")]
        [Required(ErrorMessage = "Order is required")]
        public long OrderID { get; set; }
        [Display(Name = "Date")]
        [Required]
        public string RequisitionDate { get; set; }
        [Display(Name = "Additional Required")]
        [Required(ErrorMessage = "Quantity is required")]
        public decimal RequisitionQuantity { get; set; }

        [Required(ErrorMessage = "Planing Quantity is required")]
        [Display(Name = "Additional Issue")]
        public decimal PlanQuantity { get; set; }

        //[Range(typeof(decimal), "0", "100", ErrorMessage = "Less than 100 required")]
        //[Display(Name = "Standard Effi. % ")]
        //public decimal ? StandardEfficiencyPercent { get; set; }

        //[Range(typeof(decimal), "0", "100", ErrorMessage = "Less than 100 required")]
        //[Display(Name = "Overall Effi. %")]
        //public decimal ? OverAllEfficiencyPercent { get; set; }
        public List<SelectListItem> DDLBuyer { get; set; }
        public int SearchBuyerID { get; set; }
        [Display(Name = "Order Id")]
        public int SearchOrderID { get; set; }
        [Display(Name = "Form Date")]

        public string FormDate { get; set; }
        [Display(Name = "To Date")]
        public string ToDate { get; set; }
    }
}
