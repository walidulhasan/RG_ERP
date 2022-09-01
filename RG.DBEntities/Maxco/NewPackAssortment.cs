using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class NewPackAssortment
    {
        public long Id { get; set; }
        public int PackAssortId { get; set; }
        public long ColorSetId { get; set; }
        public long SizeRangeId { get; set; }
        public int Quantity { get; set; }
    }
}
