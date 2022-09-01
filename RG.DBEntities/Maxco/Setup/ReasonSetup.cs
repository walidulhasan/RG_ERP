using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class ReasonSetup
    {
        public ReasonSetup()
        {
            TrimInspectionDetail = new HashSet<TrimInspectionDetail>();
            TrimIssueMaster = new HashSet<TrimIssueMaster>();
            YarnAdjustmentDetail = new HashSet<YarnAdjustmentDetail>();
            YarnTransferDetail = new HashSet<YarnTransferDetail>();
        }
        public int Id { get; set; }
        public int ReasonId { get; set; }
        public string ReasonDesc { get; set; }
        public string Type { get; set; }

        public virtual ICollection<TrimInspectionDetail> TrimInspectionDetail { get; set; }
        public virtual ICollection<TrimIssueMaster> TrimIssueMaster { get; set; }
        public virtual ICollection<YarnAdjustmentDetail> YarnAdjustmentDetail { get; set; }
        public virtual ICollection<YarnTransferDetail> YarnTransferDetail { get; set; }
    }
}
