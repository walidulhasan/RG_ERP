using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class ChainMachineTypeRateVersionSetup
    {
        public int Id { get; set; }
        public int ChainMachineTypeId { get; set; }
        public short VersionNo { get; set; }
        public double Rate { get; set; }
    }
}
