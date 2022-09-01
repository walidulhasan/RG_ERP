using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class LaceColor
    {
        public int ID { get; set; }
        [ForeignKey("FabricSpecificationColor")]
        public long ColorSetID { get; set; }
        public string TrimColor { get; set; }
        [ForeignKey("ColorMatching_Setup")]
        public int MatchID { get; set; }
        [ForeignKey("LaceSpecification")]
        public int ObjectID { get; set; }

        public virtual FabricSpecificationColor FabricSpecificationColor { get; set; }
        public virtual ColorMatching_Setup ColorMatching_Setup { get; set; }
        public virtual LaceSpecification LaceSpecification { get; set; }
    }
}
