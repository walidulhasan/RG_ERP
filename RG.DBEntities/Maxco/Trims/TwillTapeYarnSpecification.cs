using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class TwillTapeYarnSpecification
    {
        public TwillTapeYarnSpecification()
        {
            TwillTapeYarnSpecificationColor = new HashSet<TwillTapeYarnSpecificationColor>();
        }

        public int Id { get; set; }
        public long TwillTapeId { get; set; }
        public long YarnCountId { get; set; }
        public int YarnCompositionId { get; set; }
        public byte YarnDyeingId { get; set; }
        public int? FabricYarnVendorColorId { get; set; }

        public virtual FabricYarnVendorColor_Setup FabricYarnVendorColor { get; set; }
        public virtual TwillTapeSpecification TwillTape { get; set; }
        public virtual FabricYarnComposition_Setup YarnComposition { get; set; }
        public virtual FabricYarnCount_Setup YarnCount { get; set; }
        public virtual TwillTapeYarnDyeingSetup YarnDyeing { get; set; }
        public virtual ICollection<TwillTapeYarnSpecificationColor> TwillTapeYarnSpecificationColor { get; set; }
    }
}
