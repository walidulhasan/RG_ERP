using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Setup;
 

namespace RG.DBEntities.Maxco.Trims
{
    public partial class SizeRingColor
    {
        public int ID { get; set; }
        public int ObjectID { get; set; }
        public int SelectedSizeRangeID { get; set; }
        public string TrimColor { get; set; }
        public string TextColor { get; set; }
        public int? MatchID { get; set; }

        //public virtual ColorMatchingSetup Match { get; set; }
        //public virtual SizeRingSpecification Object { get; set; }
    }
}
