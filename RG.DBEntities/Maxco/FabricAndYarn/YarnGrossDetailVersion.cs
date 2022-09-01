using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class YarnGrossDetailVersion
    {
        public int Id { get; set; }
        public long? GrossId { get; set; }
        public long? Krsid { get; set; }
        public int? DetailId { get; set; }
    }
}
