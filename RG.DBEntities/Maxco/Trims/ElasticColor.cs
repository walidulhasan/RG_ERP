using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ElasticColor
    {
        public int ID { get; set; }
        [ForeignKey("FabricSpecificationColor")]
        public long ColorSetID { get; set; }
        public string TrimColor { get; set; }
        public int MatchID { get; set; }
        [ForeignKey("ElasticSpecification")]
        public int ObjectID { get; set; }
        public virtual ElasticSpecification ElasticSpecification { get; set; }
        public virtual FabricSpecificationColor ColorSet { get; set; }
    }
}
