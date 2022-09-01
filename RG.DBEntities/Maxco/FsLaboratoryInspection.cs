using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsLaboratoryInspection
    {
        public long Id { get; set; }
        public long AttributeInstanceId { get; set; }
        public int? ProcessId { get; set; }
        public double? FabricProcessValue { get; set; }
        public int? Status { get; set; }
        public bool? IsTrim { get; set; }
        public long? TempReceivingId { get; set; }
    }
}
