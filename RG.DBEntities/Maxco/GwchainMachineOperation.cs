using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class GwchainMachineOperation
    {[Key]
        public long GwchainMachineOperationId { get; set; }
        public long SequenceNo { get; set; }
        public long GwmachineOperationId { get; set; }
        public long GwchainId { get; set; }
        public string NoOfMachines { get; set; }
        public int OperationMachineTypeId { get; set; }
        public double CycleTime { get; set; }
        public double Capacity { get; set; }
        public double Smv { get; set; }
        public int? ProcessSequence { get; set; }

        public virtual Gwchain Gwchain { get; set; }
    }
}
