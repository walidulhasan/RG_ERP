using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Trims;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class WovenConstruction_Setup
    {
        public WovenConstruction_Setup()
        {
            FabricSpecification = new HashSet<FabricSpecification>();
        }

        public int Id { get; set; }
        public int FabricCategoryId { get; set; }
        public string Description { get; set; }
        public int? Warp { get; set; }
        public int? Weft { get; set; }
        public int? WarpNumber { get; set; }
        public int? WeftNumber { get; set; }

        public virtual ICollection<FabricSpecification> FabricSpecification { get; set; }
    }
}
