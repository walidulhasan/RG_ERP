using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class CadcamDispatchDetails
    {
        public int Id { get; set; }
        public long FabricId { get; set; }
        public long? ColorSetId { get; set; }
        public int DispatchId { get; set; }

        public virtual CadcamDispatch Dispatch { get; set; }
    }
}
