using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.Application.ViewModel.Maxco.Business.OrderPlanFollowup
{
    public class OrderPlanFollowupCreateVM
    {
        public int FollowupID { get; set; }
        [Display(Name="Order No")]
        public int OrderID { get; set; }
        [Display(Name = "Order Classification")]
        public int OrderClassificationID { get; set; }
        [Display(Name = "Additional From Stock")]
        public string AdditionalFromStock { get; set; }
        [Display(Name = "Approved Date")]
        public string ApprovedDate { get; set; }
        [Display(Name = "Packing Complete Date")]
        public string PackingCompleteDate { get; set; }
        [Display(Name = "Pre-Final Date")]
        public string PreFinalDate { get; set; }
        [Display(Name = "Is Order Closed")]
        public string IsOrderClosed { get; set; }
        [Display(Name = "Expected Sample Date")]
        public string ExpectedSampleDate { get; set; }
        [Display(Name = "PP Sample Approval Date")]
        public string PreProductionSampleApprovalDate { get; set; }
        public string Remarks { get; set; }
        public List<SelectListItem> DDLOrder { get; set; }
        public List<SelectListItem> DDLOrderClassification { get; set; }
        public List<SelectListItem> DDLYesNo { get; set; }
    }
}
