using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class WovenStripeColors
    {
        public int Id { get; set; }
        public long ColorSetId { get; set; }
        public string PantoneNo { get; set; }
        public string ColorName { get; set; }
        public int StripeNo { get; set; }
        public int IsBaseStripeColor { get; set; }
    }
}
