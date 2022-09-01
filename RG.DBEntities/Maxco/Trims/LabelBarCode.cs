using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class LabelBarCode
    {
        public int Id { get; set; }
        public int? ObjectId { get; set; }
        public int? ColorSetId { get; set; }
        public int? SelectedSizeRangeId { get; set; }
        public string BarCode { get; set; }
    }
}
