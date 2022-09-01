using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class SMVModelCost_Setup
    {
        public int ID { get; set; }
        public double Rate { get; set; }
        public int StyleID { get; set; }
        public int RateTypeID { get; set; }
        public bool? IsFromGE { get; set; }
    }
}
