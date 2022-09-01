using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class OrderPriceColorSizeWise
    {
        public int Id { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public double Price { get; set; }
        public int OrderPriceId { get; set; }
    }
}
