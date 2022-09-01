using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Setup;
namespace RG.DBEntities.Maxco.Trims
{
    public partial class ZipColor
    {
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public long? ColorSetId { get; set; }
        public string TrimColor { get; set; }
        public int MatchId { get; set; }
        public byte ZipColorTypeId { get; set; }

        public virtual FabricSpecificationColor ColorSet { get; set; }
        public virtual ColorMatching_Setup Match { get; set; }
        public virtual ZipSpecification Object { get; set; }
        public virtual ZipColorTypeSetup ZipColorType { get; set; }
    }
}
