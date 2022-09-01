using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TempWashingItemsList
    {
        public double? ItemId { get; set; }
        public string ItemName { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public int? MatCatId { get; set; }
    }
}
