using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class Temtable
    {
        public long? Id { get; set; }
        public int? FabricTypeId { get; set; }
        public int? FabricQualityId { get; set; }
        public int YarnComp { get; set; }
        public byte YarnQuality { get; set; }
        public long YarnCount { get; set; }
        public double? KnittingRate { get; set; }
    }
}
