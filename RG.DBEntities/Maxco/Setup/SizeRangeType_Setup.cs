using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class SizeRangeType_Setup
    {
        public SizeRangeType_Setup()
        {
            GarmentSizeRangeSetup = new HashSet<GarmentSizeRange_Setup>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<GarmentSizeRange_Setup> GarmentSizeRangeSetup { get; set; }
    }
}
