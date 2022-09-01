using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class ChainProcessSetupOperations
    {
        public int ChainProcessSetupId { get; set; }
        public int SequenceNo { get; set; }
        public bool IsPair { get; set; }
        public double PerPieceTime { get; set; }
        public int MachineTypeId { get; set; }
        public int RequiredMachines { get; set; }
        public string AttachmentId { get; set; }
        public short Helper { get; set; }
        public double? OperationRate { get; set; }
        public int ChainOperationId { get; set; }
        public bool? IsOffline { get; set; }
        public int Id { get; set; }
        public double? MoveTime { get; set; }
        public int? ToGroupId { get; set; }
    }
}
