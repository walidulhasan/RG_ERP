using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CottonIssuanceRequisitionMaster
    {
        public CottonIssuanceRequisitionMaster()
        {
            CottonIssuanceRequisitionDetail = new HashSet<CottonIssuanceRequisitionDetail>();
        }

        public int Id { get; set; }
        public string IssReqNo { get; set; }
        public string ReqDate { get; set; }
        public DateTime CreationDate { get; set; }
        public int? Status { get; set; }
        public int? UserId { get; set; }
        public int? ApprovedBy { get; set; }

        public virtual ICollection<CottonIssuanceRequisitionDetail> CottonIssuanceRequisitionDetail { get; set; }
    }
}
