using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class GarmentWiseFabricTrimSetup
    {
        public int Id { get; set; }
        public long FabricTrimId { get; set; }
        public int GarmentTypeId { get; set; }
        public DateTime CreationDate { get; set; }
        public long UserId { get; set; }
    }
}
