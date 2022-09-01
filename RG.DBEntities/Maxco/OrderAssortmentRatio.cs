using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class OrderAssortmentRatio
    {
        public int Id { get; set; }
        public int? ShippmentPackingId { get; set; }
        public bool? IsTarget { get; set; }
        public short? Value { get; set; }
        public bool? IsColorSet { get; set; }
        public int? SetId { get; set; }
        public int? ShippmentPackingStyleId { get; set; }

        public virtual OrderShippmentPacking ShippmentPacking { get; set; }
    }
}
