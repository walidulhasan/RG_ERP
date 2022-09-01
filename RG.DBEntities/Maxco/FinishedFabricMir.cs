using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FinishedFabricMir
    {
        public int Id { get; set; }
        public int FabricId { get; set; }
        public int FabricTypeId { get; set; }
        public int FabricQualityId { get; set; }
        public int FabricComposition { get; set; }
        public int Gsm { get; set; }
        public byte MachineTypeId { get; set; }
        public bool IsSpandex { get; set; }
        public byte DyeingLevel { get; set; }
        public string Color { get; set; }
        public string MatchingSource { get; set; }
        public byte? DyeingProcessId { get; set; }
        public bool IsBrushingRequired { get; set; }
        public bool IsFinishingRequired { get; set; }
        public bool IsTumbleDryingRequired { get; set; }
        public bool IsCentrifugalRequired { get; set; }
        public bool IsSimpleFinishRequired { get; set; }
        public bool? IsShellFabric { get; set; }
        public int? DivisorLength { get; set; }
        public int Width { get; set; }
        public byte? Status { get; set; }
        public int Quantity { get; set; }
        public string WashingSpecification { get; set; }
        public string BrushingSpecification { get; set; }
        public DateTime? Date { get; set; }
    }
}
