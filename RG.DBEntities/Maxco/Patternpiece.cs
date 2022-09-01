using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class Patternpiece
    {
        public long Expr1 { get; set; }
        public int Id { get; set; }
        public long? FabricSpecificationSetupId { get; set; }
        public int? QualityId { get; set; }
        public short? Gsm { get; set; }
        public byte? MachineTypeId { get; set; }
        public byte? GaugeId { get; set; }
        public byte? DyeingId { get; set; }
        public byte? ShrinkageWidth { get; set; }
        public byte? ShrinkageLength { get; set; }
        public int? FabricParentId { get; set; }
        public short? ImageId { get; set; }
        public int ColorParentId { get; set; }
        public int? FabricTrimSelectedId { get; set; }
        public byte? PalleteTypeId { get; set; }
        public bool? IsSpandex { get; set; }
        public string Comments { get; set; }
        public double? FinishedWidth { get; set; }
        public byte? MatchingSourceId { get; set; }
        public bool? IsFinishingRequired { get; set; }
        public int? Spandex { get; set; }
        public string FabricComposition { get; set; }
        public byte? DenimWeightId { get; set; }
        public byte? FabricCategoryId { get; set; }
        public byte? WovenConstructionId { get; set; }
        public byte? WovenCompositionId { get; set; }
        public byte? NoOfWales { get; set; }
        public bool? IsDivisor { get; set; }
        public int? DivisorLength { get; set; }
        public string SizeRangeComments { get; set; }
        public byte? FastnessStandardId { get; set; }
        public int? PrintImageId { get; set; }
        public int? DenimBuyerId { get; set; }
        public string DenimBuyerCode { get; set; }
        public int? FabricTension { get; set; }
    }
}
