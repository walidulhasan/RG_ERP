using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblMachines
    {
        public long MachineId { get; set; }
        public int FammachineId { get; set; }
        public int MachineNo { get; set; }
        public string MachineName { get; set; }
        public int MachineTypeId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int? Gauge { get; set; }
        public double? Dia { get; set; }
        public int? Rpm { get; set; }
        public int? NoOfFeeders { get; set; }
        public int? Status { get; set; }
        public int? LeadTime { get; set; }
        public string Description { get; set; }
        public double? Smv { get; set; }
        public long? KnitterId { get; set; }
    }
}
