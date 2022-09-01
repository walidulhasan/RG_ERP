using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class Assortment
    {
        public int Id { get; set; }
        public int PackingTypeId { get; set; }
        public int SizeSetId { get; set; }
        public int ColorSetId { get; set; }
        public int Value { get; set; }
        public int? OriginalGsc { get; set; }
        public int? TargetGsc { get; set; }
        public int ShipmentPackingStyleId { get; set; }
        public int? PackNo { get; set; }
        public int? GroupNo { get; set; }
    }
}
