using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsFabricTransfer
    {
        public long Id { get; set; }
        public long FromAttributeInstanceId { get; set; }
        public long? FromFid { get; set; }
        public long ToFid { get; set; }
        public int Department { get; set; }
    }
}
