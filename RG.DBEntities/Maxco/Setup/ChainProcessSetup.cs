using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class ChainProcessSetup
    {
        public int Id { get; set; }
        public int StyleId { get; set; }
        public short VersionNo { get; set; }
        public DateTime CreationDate { get; set; }
        public string Comments { get; set; }
        public short Status { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public double? NMax { get; set; }
        public double? BaseRate { get; set; }
        public double? LeadTime { get; set; }
        public int? Qo { get; set; }
        public int? PhysicalLimit { get; set; }
        public double? Wastage { get; set; }
        public bool? IsStitch { get; set; }
        public double? MachineSmv { get; set; }
        public double? HandSmv { get; set; }
        public bool? Ge2 { get; set; }
    }
}
