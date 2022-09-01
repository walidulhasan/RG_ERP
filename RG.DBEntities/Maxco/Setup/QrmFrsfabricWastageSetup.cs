using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class QrmFrsfabricWastageSetup
    {
        public int Id { get; set; }
        public int? FabricTypeId { get; set; }
        public int? DyeingTypeId { get; set; }
        public int? ProcessingId { get; set; }
        public int Wastage { get; set; }
        public double? Value { get; set; }
        public int? IsCuttingWastage { get; set; }
        public int? IsDyeingWastage { get; set; }
        public int? IsProcessingWastage { get; set; }
        public int? IsKnittingWastage { get; set; }
        public int? IsWashingWastage { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? CreationDate1 { get; set; }
        public int? PrintCodeId { get; set; }
        public int? IsPrintWastage { get; set; }
    }
}
