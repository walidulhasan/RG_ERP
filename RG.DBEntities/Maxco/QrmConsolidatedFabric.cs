using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class QrmConsolidatedFabric
    {
        public long Id { get; set; }
        public long? StyleId { get; set; }
        public string ConsolidatedFabricXml { get; set; }
    }
}
