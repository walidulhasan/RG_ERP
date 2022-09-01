using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;


namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class YarnAdjustmentDetail
    {
        [Key]
        public int YadjustmentDid { get; set; }
        public int MadjustmentMid { get; set; }
        public int MadjustmentReasonId { get; set; }
        public int? YarnInventoryId { get; set; }

        public virtual ReasonSetup MadjustmentReason { get; set; }
        public virtual YarnInventory YarnInventory { get; set; }
    }
}
