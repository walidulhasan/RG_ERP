using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class ModelOtherFabricTrimConsumption
    {
        public int Id { get; set; }
        public long? StyleId { get; set; }
        public string MaterialSpecsXml { get; set; }
    }
}
