using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WoRollDefectDetail
    {
        public long RollDefectDetailId { get; set; }
        public long? DfsRollInspectionAttributeId { get; set; }
        public double? Size { get; set; }
        public string DefectDirection { get; set; }
        public int? ProcessId { get; set; }
        public double? DefectStartFrom { get; set; }
    }
}
