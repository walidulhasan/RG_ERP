using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class CollectionWisePriceSetup
    {
        public int Id { get; set; }
        public int CollectionId { get; set; }
        public int ItemSetupId { get; set; }
        public bool? IsTrimRate { get; set; }
        public bool? IsPantoneRate { get; set; }
        public bool? IsPrintingRate { get; set; }
        public bool? IsKnittingRate { get; set; }
        public bool? IsSmvrate { get; set; }
        public bool? IsWastage { get; set; }
        public double? Price { get; set; }
        public double? SimulatedPrice { get; set; }
        public byte? TrimId { get; set; }
        public bool? IsEmbroRate { get; set; }
        public bool? IsWashingFinishingRate { get; set; }
        public bool? IsSimpleYarnRate { get; set; }
        public int IsHeatherYarnRate { get; set; }
        public int? HeatherYarnUnitId { get; set; }
        public bool? IsDyedYarnRate { get; set; }
        public double? Fob { get; set; }
        public double? Frieght { get; set; }
        public double? Duty { get; set; }
        public double? Clrtotal { get; set; }
        public bool? IsOtherFabricRate { get; set; }
        public int? VendorId { get; set; }
        public int? CurrencyId { get; set; }
        public int TestId { get; set; }
    }
}
