using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class SMVRate_Setup
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public double Rate_Per_Min { get; set; }
        public bool? IsRateInsert { get; set; }
        public int? FabricCategoryID { get; set; }
        public bool? IsApplicable { get; set; }
        public int? SMVProcessSetupID { get; set; }
    }
}
