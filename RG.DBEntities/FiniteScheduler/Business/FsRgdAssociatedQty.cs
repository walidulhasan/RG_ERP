using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class FsRgdAssociatedQty
    {
        public int Id { get; set; }
        public long SizeId { get; set; }
        public long ColorId { get; set; }
        public long StyleId { get; set; }
        public long Quantity { get; set; }
    }
}
