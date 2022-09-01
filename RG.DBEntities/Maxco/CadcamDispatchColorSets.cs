using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class CadcamDispatchColorSets
    {
        public int Id { get; set; }
        public int DispatchId { get; set; }
        public int ColorSetId { get; set; }

        public virtual CadcamDispatch Dispatch { get; set; }
    }
}
