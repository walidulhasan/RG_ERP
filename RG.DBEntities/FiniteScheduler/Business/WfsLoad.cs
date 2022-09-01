using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WfsLoad
    {
        public long Id { get; set; }
        public int? MachineId { get; set; }
        public int MinuteId { get; set; }
        public int WcdayId { get; set; }
        public long JobId { get; set; }
        public byte Status { get; set; }
        public int? ManualOperationId { get; set; }
    }
}
