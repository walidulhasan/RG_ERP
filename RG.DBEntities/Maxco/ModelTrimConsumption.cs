using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class ModelTrimConsumption
    {
        public int Id { get; set; }
        public long StyleId { get; set; }
        public int? TrimId { get; set; }
        public int? TrimImageId { get; set; }
        public double? Consumption { get; set; }
        public string TrimSpecsXml { get; set; }
    }
}
