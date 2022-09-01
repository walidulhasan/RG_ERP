using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsFabricProcessAssociation
    {
        public long Id { get; set; }
        public long? AttributeInstanceId { get; set; }
        public int? ProcessId { get; set; }
    }
}
