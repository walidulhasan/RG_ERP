using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class SizeChartPlacementSetup
    {
        public int Id { get; set; }
        public short PlacementPointId { get; set; }
        public byte GarmentTypeId { get; set; }
        public byte GenderId { get; set; }
        public byte BuyerId { get; set; }

        public virtual GarmentType_Setup GarmentType { get; set; }
        public virtual Gender_Setup Gender { get; set; }
        public virtual PlacementPointSetup PlacementPoint { get; set; }
    }
}
