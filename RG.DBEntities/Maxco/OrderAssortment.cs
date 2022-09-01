using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class OrderAssortment
    {
        public int Id { get; set; }
        public int ShippmentPackingStyleId { get; set; }
        public int SizeSetId { get; set; }
        public int ColorSetId { get; set; }
        public int Value { get; set; }
        public int OriginalGsc { get; set; }
        public int? TargetGsc { get; set; }
        public string LabelCode { get; set; }

        public virtual OrderShippmentPackingStyle ShippmentPackingStyle { get; set; }
    }
}
