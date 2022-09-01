using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class LeatherSpecificationSetup
    {
        public int Id { get; set; }
        public int FabricSpecificationSetupId { get; set; }
        public int MaterialTypeId { get; set; }
        public int? LeatherTypeId { get; set; }
        public int? LeatherQualityId { get; set; }
        public string MaterialThickness { get; set; }
        public int? LeatherSkinId { get; set; }
        public int? RexeneSupplierCodeId { get; set; }
    }
}
