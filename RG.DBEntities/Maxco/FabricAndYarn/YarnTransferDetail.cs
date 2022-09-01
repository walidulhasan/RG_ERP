using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class YarnTransferDetail
    {
       [Key]
        public int YtransferDid { get; set; }
        public int MtransferMid { get; set; }
        public int MtransferReasonId { get; set; }
        public int SourceYarnInventoryId { get; set; }
        public int DestinationYarnInventoryId { get; set; }

        public virtual YarnInventory DestinationYarnInventory { get; set; }
        public virtual ReasonSetup MtransferReason { get; set; }
        public virtual YarnInventory SourceYarnInventory { get; set; }
    }
}
