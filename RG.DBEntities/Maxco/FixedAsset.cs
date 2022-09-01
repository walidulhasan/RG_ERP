using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FixedAsset
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Finance { get; set; }
        public string Class { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Item { get; set; }
        public string ItemCode { get; set; }
        public string ProfitCenter { get; set; }
        public double? OldNo { get; set; }
        public long? CategoryId { get; set; }
    }
}
