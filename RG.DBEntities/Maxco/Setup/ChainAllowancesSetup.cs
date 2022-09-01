using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class ChainAllowancesSetup
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public short? Allowance { get; set; }
        public bool IsChain { get; set; }
    }
}
