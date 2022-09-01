using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco
{
    public partial class BiFacedFabricColors
    {
        public int Id { get; set; }
        public long ColorSetId { get; set; }
        public string PantoneNo { get; set; }
        public int DyeingProcessId { get; set; }
        public string ColorName { get; set; }
        public int MatchingSourceId { get; set; }
        public int PalletTypeId { get; set; }

        public virtual FabricSpecificationColor ColorSet { get; set; }
    }
}
