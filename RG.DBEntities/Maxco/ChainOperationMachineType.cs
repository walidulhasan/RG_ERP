using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class ChainOperationMachineType
    {
        public int Id { get; set; }
        public int ChainMachineTypeId { get; set; }
        public int ChainOperationsId { get; set; }
        public double MaxTime { get; set; }
        public double? MaxTimePair { get; set; }
    }
}
