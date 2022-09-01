using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricYarnCosting_Setup
    {
        public FabricYarnCosting_Setup()
        {
            //FabricYarnVendor = new HashSet<FabricYarnVendor>();
        }

        public int ID { get; set; }
        public int FabricYarnCompositionID { get; set; }
        public int FabricYarnQualityID { get; set; }
        public int FabricYarnUnitID { get; set; }
        public int FabricYarnCountID { get; set; }
        public bool? FabricYarnIsDyed { get; set; }
        public string ColorType { get; set; }
        public string MaxcoCode { get; set; }
        public int? FabricDyedYarnPrice { get; set; }

        public virtual FabricYarnComposition_Setup FabricYarnComposition { get; set; }
        public virtual FabricYarnQuality_Setup FabricYarnQuality_Setup { get; set; }
       // public virtual FabricYarnUnitSetup FabricYarnUnit { get; set; }
       public virtual ICollection<FabricYarnVendor> FabricYarnVendor { get; set; }
    }
}
