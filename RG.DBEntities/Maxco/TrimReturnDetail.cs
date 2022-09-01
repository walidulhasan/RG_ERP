using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TrimReturnDetail
    {
        public int Id { get; set; }
        public int TrimReturnDid { get; set; }
        public int MreturnMid { get; set; }
        public double ReturnQuantity { get; set; }
        public int TrimIqid { get; set; }

        public virtual TrimInventoryQuantity TrimIq { get; set; }
    }
}
