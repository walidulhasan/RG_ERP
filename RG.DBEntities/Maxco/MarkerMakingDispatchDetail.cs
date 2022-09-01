using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class MarkerMakingDispatchDetail
    {
        public int Id { get; set; }
        public long DispatchId { get; set; }
        public int FabricId { get; set; }
        public int ColorSetId { get; set; }
        public int ShellColorSetId { get; set; }
        public int? TrimId { get; set; }

        public virtual MarkerMakingDispatch Dispatch { get; set; }
    }
}
