using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsOrderFabricReceivedQtytemp
    {
        public int Id { get; set; }
        public long? OrderId { get; set; }
        public string ConsolidatedFabricXml { get; set; }
    }
}
