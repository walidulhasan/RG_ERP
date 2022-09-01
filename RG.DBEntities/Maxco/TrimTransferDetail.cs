using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class TrimTransferDetail
    {
        [Key]
        public int TtransferDid { get; set; }
        public int MtransferMid { get; set; }
        public int SourceTrimIqid { get; set; }
        public int DestinationLocationId { get; set; }
        public double MovedQty { get; set; }

        public virtual TrimInventoryQuantity SourceTrimIq { get; set; }
    }
}
