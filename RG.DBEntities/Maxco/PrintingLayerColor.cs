using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class PrintingLayerColor
    {
        public int Id { get; set; }
        public int? ObjectId { get; set; }
        public long? ColorSetId { get; set; }
        public string TrimColor { get; set; }
    }
}
