using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Trims;

namespace RG.DBEntities.Maxco
{
    public partial class VelcroColor
    {
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public string TrimColor { get; set; }
        public long ColorSetId { get; set; }
        public byte MatchId { get; set; }

        public virtual FabricSpecificationColor ColorSet { get; set; }
        public virtual VelcroSpecification Object { get; set; }
    }
}
