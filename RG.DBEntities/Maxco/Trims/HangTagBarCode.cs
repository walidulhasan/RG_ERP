using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class HangTagBarCode
    {
        public int Id { get; set; }
        public long? ObjectId { get; set; }
        public long? ColorSetId { get; set; }
        public long? SelectedSizeRangeId { get; set; }
        public string BarCode { get; set; }
    }
}
