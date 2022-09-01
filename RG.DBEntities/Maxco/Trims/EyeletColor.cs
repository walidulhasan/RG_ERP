using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;


namespace RG.DBEntities.Maxco.Trims
{
    public partial class EyeletColor
    {
        public int ID { get; set; }
        public int ObjectID { get; set; }
        public string TrimColor { get; set; }
        public int? MatchID { get; set; }
        public long? ColorSetID { get; set; }

        //public virtual FabricSpecificationColor ColorSet { get; set; }
        //public virtual ColorMatchingSetup Match { get; set; }
        //public virtual EyeletSpecification Object { get; set; }
    }
}
