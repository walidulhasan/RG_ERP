using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CottonIssuanceMaster
    {
        public CottonIssuanceMaster()
        {
            CottonIssuanceDetail = new HashSet<CottonIssuanceDetail>();
        }

        public int Id { get; set; }
        public string IssuanceNo { get; set; }
        public DateTime IssuanceDate { get; set; }
        public string ReceivingPerson { get; set; }
        public int RequisitionId { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<CottonIssuanceDetail> CottonIssuanceDetail { get; set; }
    }
}
