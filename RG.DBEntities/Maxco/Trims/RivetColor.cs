using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Setup;
 
namespace RG.DBEntities.Maxco.Trims
{
    public partial class RivetColor
    {
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public long ColorSetId { get; set; }
        public string TrimColor { get; set; }
        public byte? MatchId { get; set; }

        public virtual FabricSpecificationColor ColorSet { get; set; }
        public virtual RivetSpecification Object { get; set; }
    }
}
