using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class CollectionWiseCostSetup
    {
        public int Id { get; set; }
        public int CollectionId { get; set; }
        public int TrimId { get; set; }
        public int SetupId { get; set; }
        public bool IsTrimRate { get; set; }
        public bool IsPantoneRate { get; set; }
        public bool IsPercentageRate { get; set; }
        public bool IsEmbroPrintingRate { get; set; }
        public bool IsWashingFinishingRate { get; set; }
        public bool IsFabricYarnRate { get; set; }
    }
}
