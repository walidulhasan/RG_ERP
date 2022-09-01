using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class YarnIssueDetail
    {
        [Key]
        public int YarnIssueDid { get; set; }
        public int YarnIssueMid { get; set; }
        public int YarnInventoryId { get; set; }

        public virtual YarnInventory YarnInventory { get; set; }
        public virtual YarnIssueMaster YarnIssueM { get; set; }
    }
}
