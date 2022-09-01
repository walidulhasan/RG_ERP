using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Setup
{
    public class GarmentSizeRange_Setup
    {
        public GarmentSizeRange_Setup()
        {
            SelectedGarmentSizeRange = new HashSet<SelectedGarmentSizeRange>();
        }

        public int ID { get; set; }
        public int SizeRangeRegionID { get; set; }
        public int GenderID { get; set; }
        public int SizeRangeTypeID { get; set; }
        public int GarmentTypeID { get; set; }
        public int Sno { get; set; }
        public string Description { get; set; }

        public virtual GarmentType_Setup GarmentType { get; set; }
        public virtual Gender_Setup Gender { get; set; }
        public virtual SizeRangeRegion_Setup SizeRangeRegion { get; set; }
        public virtual SizeRangeType_Setup SizeRangeType_Setup { get; set; }
        public virtual ICollection<SelectedGarmentSizeRange> SelectedGarmentSizeRange { get; set; }
    }
}
