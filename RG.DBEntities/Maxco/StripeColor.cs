using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class StripeColor
    {
        public int Id { get; set; }
        public int ColorsetId { get; set; }
        public int StripeId { get; set; }
        public string Color { get; set; }
    }
}
