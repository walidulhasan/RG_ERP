using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsRejectedFabricRejections
    {
        public int Id { get; set; }
        public int RejectionDetailId { get; set; }
        public int RejectedFabricId { get; set; }

        public virtual FsRejectedFabric RejectedFabric { get; set; }
    }
}
