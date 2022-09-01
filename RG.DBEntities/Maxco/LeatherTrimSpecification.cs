using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LeatherTrimSpecification
    {
        public int Id { get; set; }
        public int FabricSpecificationId { get; set; }
        public int? LeatherTypeId { get; set; }
        public int? LeatherSkinId { get; set; }
        public byte? IsCrust { get; set; }
        public byte? IsDyedCrust { get; set; }
        public int? LeatherQualityId { get; set; }
        public string MaterialThickness { get; set; }
        public int? RexeneSupplierCodeId { get; set; }
        public int? MaterialTypeId { get; set; }
    }
}
