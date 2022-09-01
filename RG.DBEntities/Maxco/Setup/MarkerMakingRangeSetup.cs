using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class MarkerMakingRangeSetup
    {
        public int Id { get; set; }
        public int? FabricTypeId { get; set; }
        public int? FabricQtyId { get; set; }
        public int Range { get; set; }
    }
}
