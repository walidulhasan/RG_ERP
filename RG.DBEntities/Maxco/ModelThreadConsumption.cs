using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class ModelThreadConsumption
    {
        public int Id { get; set; }
        public long? StyleId { get; set; }
        public int? Consumption { get; set; }
        public string ThreadSpecsXml { get; set; }
    }
}
