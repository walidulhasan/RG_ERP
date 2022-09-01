using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class WashingMachineSetup
    {
        public int MachineId { get; set; }
        public int MachineTypeId { get; set; }
        public string MachineName { get; set; }
        public string DepartmentNo { get; set; }
        public byte MachineStatus { get; set; }
        public decimal? MachineCapacity { get; set; }
        public int? CapacityUnitId { get; set; }
        public int? FamassetId { get; set; }
        public int? UserId { get; set; }
        public bool Deleted { get; set; }
        public DateTime Date { get; set; }
        public byte? IsProduction { get; set; }
    }
}
