using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class BuckleColor
    {
        [Key]
        public int ID { get; set; }
        public long? ColorSetID { get; set; }
        public string TrimColor { get; set; }
        public int? MatchID { get; set; }
        public long ObjectID { get; set; }

     //   public virtual FabricSpecificationColor ColorSet { get; set; }
      //  public virtual ColorMatchingSetup Match { get; set; }
        public virtual BuckleSpecification BuckleSpecification { get; set; }
    }
}
