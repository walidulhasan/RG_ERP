using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class LeatherTrimSpecificationSetup
    {
        public int Id { get; set; }
        public long FabricSpecificationId { get; set; }
        public int? LeatherTypeId { get; set; }
        public int? LeatherSkinId { get; set; }
        public byte? IsCrust { get; set; }
        public byte? IsSemiAnaline { get; set; }
        public byte? IsPigmentFinish { get; set; }
        public byte? IsMillGrainFinish { get; set; }
        public byte? IsAnaline { get; set; }
        public byte? IsGlazeFinish { get; set; }
        public int? LeatherThicknessId { get; set; }
        public int? ThicknessMeasurementId { get; set; }
        public byte? IsLeatherFinishType { get; set; }
        public int? LeatherFinishTypeId { get; set; }
    }
}
