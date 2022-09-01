using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class CmblConsolidatedFabricIssQuantitytemp
    {
        public long Id { get; set; }
        public long? OrderId { get; set; }
        public string ConsolidatedFabricXml { get; set; }
    }
}
