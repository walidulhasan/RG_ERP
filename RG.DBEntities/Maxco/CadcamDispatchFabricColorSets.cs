using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class CadcamDispatchFabricColorSets
    {
        public int Id { get; set; }
        public int DispatchId { get; set; }
        public long ColorSetId { get; set; }
    }
}
