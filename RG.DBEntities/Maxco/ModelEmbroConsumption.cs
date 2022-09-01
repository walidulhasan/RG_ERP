using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class ModelEmbroConsumption
    {
        public int Id { get; set; }
        public long? StyleId { get; set; }
        public long? EmbroImageId { get; set; }
        public int? Consumption { get; set; }
        public string EmbroSpecsXml { get; set; }
    }
}
