using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class FurColor
    {
        public int Id { get; set; }
        public long ColorSetId { get; set; }
        public string TrimColor { get; set; }
        public int? MatchId { get; set; }
        public long ObjectId { get; set; }

        public virtual FabricSpecificationColor ColorSet { get; set; }
        public virtual ColorMatching_Setup Match { get; set; }
        public virtual FurSpecification Object { get; set; }
    }
}
