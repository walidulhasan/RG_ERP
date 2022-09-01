using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class Gender_Setup
    {
        public Gender_Setup()
        {
            BuyerCodeSetup = new HashSet<BuyerCodeSetup>();
            Collection = new HashSet<Collection>();
            GarmentSizeRangeSetup = new HashSet<GarmentSizeRange_Setup>();
            SizeChartPlacementSetup = new HashSet<SizeChartPlacementSetup>();
        }

        public byte ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<BuyerCodeSetup> BuyerCodeSetup { get; set; }
        public virtual ICollection<Collection> Collection { get; set; }
        public virtual ICollection<GarmentSizeRange_Setup> GarmentSizeRangeSetup { get; set; }
        public virtual ICollection<SizeChartPlacementSetup> SizeChartPlacementSetup { get; set; }
    }
}
