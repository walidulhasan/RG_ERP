using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class ModelFinishFabricConsumption
    {
        public int Id { get; set; }
        public long? Mgfcid { get; set; }
        public long StyleId { get; set; }
        public int? FabricId { get; set; }
        public double? FinishFabricConsumption { get; set; }
        public bool? IsPrinting { get; set; }
        public bool? IsDyeing { get; set; }
        public bool? IsBleaching { get; set; }
        public double? PrintingPrice { get; set; }
        public double? DyeingPrice { get; set; }
        public double? BleachingPrice { get; set; }
        public int? FabircUnitId { get; set; }
        public string FinishFabricSpecsXml { get; set; }
    }
}
