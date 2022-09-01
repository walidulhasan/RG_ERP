using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricSpecificationSetup
    {
        public FabricSpecificationSetup()
        {
            FabricYarnSpecificationSetup = new HashSet<FabricYarnSpecificationSetup>();
        }

        public long Id { get; set; }
        public string FabricCode { get; set; }
        public int? QualityId { get; set; }
        public int? Gsm { get; set; }
        public int? MachineTypeId { get; set; }
        public int? GaugeId { get; set; }
        public double? DyeingId { get; set; }
        public int? ShrinkageWidth { get; set; }
        public int? ShrinkageLength { get; set; }
        public int? ImageId { get; set; }
        public bool? IsSpandex { get; set; }
        public string Comments { get; set; }
        public double? FinishedWidth { get; set; }
        public int? MatchingSourceId { get; set; }
        public bool? IsFinishingRequired { get; set; }
        public int? Spandex { get; set; }
        public string FabricComposition { get; set; }
        public int? DenimWeightId { get; set; }
        public int? FabricCategoryId { get; set; }
        public int? WovenConstructionId { get; set; }
        public int? WovenCompositionId { get; set; }
        public int? NoOfWales { get; set; }
        public string SizeRangeComments { get; set; }
        public int? FastnessStandardId { get; set; }
        public int? PrintImageId { get; set; }
        public int? DenimBuyerId { get; set; }
        public string DenimBuyerCode { get; set; }
        public bool? IsDivisor { get; set; }
        public double? DivisorLength { get; set; }
        public int? UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public int? Status { get; set; }
        public int? PalleteTypeId { get; set; }
        public bool? IsLeather { get; set; }
        public double? Rate { get; set; }
        public byte? DestinationId { get; set; }
        public int? VendorId { get; set; }
        public int? UserSelectedUnitId { get; set; }
        public string BuyerCode { get; set; }
        public int? WeaveTypeId { get; set; }

        public virtual ICollection<FabricYarnSpecificationSetup> FabricYarnSpecificationSetup { get; set; }
    }
}
