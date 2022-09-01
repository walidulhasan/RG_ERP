using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WashingLotToppingDetail
    {
        public long Id { get; set; }
        public long? ToppingMasterId { get; set; }
        public long? RecipeMaterialId { get; set; }
        public double? Quantity { get; set; }
        public int? UnitId { get; set; }
        public int? Percentage { get; set; }
    }
}
