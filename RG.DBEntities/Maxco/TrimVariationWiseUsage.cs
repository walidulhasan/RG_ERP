using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TrimVariationWiseUsage
    {
        public int Id { get; set; }
        public long ObjectId { get; set; }
        public int TrimId { get; set; }
        public long ColorSetId { get; set; }
        public long SizeSetId { get; set; }
        public int Quantity { get; set; }
    }
}
