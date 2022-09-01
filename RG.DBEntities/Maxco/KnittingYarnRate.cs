using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco
{
    public partial class KnittingYarnRate
    {
        public int Id { get; set; }
        public int KnittingRateId { get; set; }
        public int YarnCompositionId { get; set; }
        public int YarnQualityId { get; set; }
        public int YarnCountId { get; set; }
        public int? PantoneNo { get; set; }

        public virtual KnittingRateSetup KnittingRate { get; set; }
    }
}
