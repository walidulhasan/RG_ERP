using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class ModelPrintConsumption
    {
        public int Id { get; set; }
        public long? StyleId { get; set; }
        public long? PrintImageId { get; set; }
        public int? Consumption { get; set; }
        public string PrintSpecsXml { get; set; }
    }
}
