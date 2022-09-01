using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class ChainMachineConstraints
    {
        public int Id { get; set; }
        public int ChainProcessSetupId { get; set; }
        public int ChainMachineTypeId { get; set; }
        public int Quantity { get; set; }
    }
}
