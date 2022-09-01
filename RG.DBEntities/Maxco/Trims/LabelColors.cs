using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Trims;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class LabelColors
    {
        public int ID { get; set; }
        [ForeignKey("FabricSpecificationColor")]
        public long ColorSetID { get; set; }
        public string TrimColor { get; set; }
        [ForeignKey("LabelSpecification")]
        public int LabelSpecificationID { get; set; }
        public int MatchID { get; set; }

        public virtual FabricSpecificationColor FabricSpecificationColor { get; set; }
        public virtual LabelSpecification LabelSpecification { get; set; }
    }
}
