using System;
using System.ComponentModel.DataAnnotations;

namespace RG.Application.ViewModel.EMS.Business.ShipmentReport
{
    public class DocumentPurchasePercentVM
    {
        [Display(Name = "Date From")]
        public DateTime? DateFrom { get; set; }
        [Display(Name = "Date To")]
        public DateTime? DateTo { get; set; }
        [Display(Name = "Purchase Ratio")]
        public bool WithPurchaseRatio { get; set; }
    }
}
