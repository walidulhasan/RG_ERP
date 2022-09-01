using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class MaSubmission
    {
        public int Id { get; set; }
        public int MaelementId { get; set; }
        public string CourierNo { get; set; }
        public DateTime? FinalApprovalDate { get; set; }
        public string SubmissionDate { get; set; }
        public int CourierId { get; set; }
       
    }
}
