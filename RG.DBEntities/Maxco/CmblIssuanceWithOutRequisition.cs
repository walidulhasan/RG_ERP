using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class CmblIssuanceWithOutRequisition
    {
       
        public int IssuanceId { get; set; }
        public DateTime IssuanceDate { get; set; }
        public string ReceivingPerson { get; set; }
        public int? ActivityId { get; set; }
        public string Remarks { get; set; }
        public string RequisitionNo { get; set; }
        public int UserId { get; set; }
        public int IssuanceNo { get; set; }
        public int CompanyId { get; set; }
        public int Deleted { get; set; }
        public int? YarnKncontractId { get; set; }
        public int? OrderId { get; set; }
        public long? StyleId { get; set; }
    }
}
