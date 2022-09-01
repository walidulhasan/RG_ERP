using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricSpecificationColorSetup
    {
        
        public long FabricSpecificationId { get; set; }
        public string PantoneNo { get; set; }
        public int? DyeingProcessId { get; set; }
        public long Id { get; set; }
        public int? FabricYarnVendorColorId { get; set; }
        public string ColorName { get; set; }
        public int? MatchingSourceId { get; set; }
        public int? PalletTypeId { get; set; }
        public long? ShellColorId { get; set; }
        public int? ColorIndex { get; set; }
    }
}
