using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class ModelAppPrintConsumption
    {
        public int Id { get; set; }
        public long? StyleId { get; set; }
        public long? AppPrintImageId { get; set; }
        public int? Consumption { get; set; }
        public string AppPrintSpecsXml { get; set; }
    }
}
