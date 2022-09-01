using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class SizeRangeRegion_Setup
    {
        public SizeRangeRegion_Setup()
        {
            GarmentSizeRangeSetup = new HashSet<GarmentSizeRange_Setup>();
        }

        public byte ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<GarmentSizeRange_Setup> GarmentSizeRangeSetup { get; set; }
    }
}
