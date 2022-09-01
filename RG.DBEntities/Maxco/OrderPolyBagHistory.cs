using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class OrderPolyBagHistory
    {
        public int Id { get; set; }
        public int PolyBagId { get; set; }
        public short UserId { get; set; }
        public DateTime ChangedOn { get; set; }
        public int VersionNo { get; set; }
    }
}
