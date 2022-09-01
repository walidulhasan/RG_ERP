using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TrimIssueDetail
    {
        public int Id { get; set; }
        public int TrimIssueDid { get; set; }
        public int TrimIssueMid { get; set; }
        public int TrimIqid { get; set; }
        public double IssuedQuantity { get; set; }

        public virtual TrimInventoryQuantity TrimIq { get; set; }
        public virtual TrimIssueMaster TrimIssueM { get; set; }
    }
}
