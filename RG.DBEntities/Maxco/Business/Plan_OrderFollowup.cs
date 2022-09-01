using System;

namespace RG.DBEntities.Maxco.Business
{
    public class Plan_OrderFollowup : DefaultTableProperties
    {
        public int FollowupID { get; set; }
        public int OrderID { get; set; }
        public int OrderClassificationID { get; set; }
        public decimal? AdditionalFromStock { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public DateTime? PackingCompleteDate { get; set; }
        public DateTime? PreFinalDate { get; set; }
        public bool IsOrderClosed { get; set; }
        public DateTime? ExpectedSampleDate { get; set; }
        public DateTime? PreProductionSampleApprovalDate { get; set; }
        public string Remarks { get; set; }

    }
}
