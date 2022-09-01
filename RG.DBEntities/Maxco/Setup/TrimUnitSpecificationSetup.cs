using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class TrimUnitSpecificationSetup
    {
        public int Id { get; set; }
        public byte TrimId { get; set; }
        public int UnitId { get; set; }
    }
}
