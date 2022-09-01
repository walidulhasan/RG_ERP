using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.Setup;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class TwillTapeColor
    {
        public int ID { get; set; }
        [ForeignKey("FabricSpecificationColor")] 
        public long ColorSetID { get; set; }
        public string TrimColor { get; set; }
        [ForeignKey("ColorMatching_Setup")]
        public int? MatchID { get; set; }
        [ForeignKey("TwillTapeSpecification")]
        public long ObjectID { get; set; }

        public virtual FabricSpecificationColor ColorSet { get; set; }
        public virtual ColorMatching_Setup Match { get; set; }
        public virtual TwillTapeSpecification Object { get; set; }
    }
}
