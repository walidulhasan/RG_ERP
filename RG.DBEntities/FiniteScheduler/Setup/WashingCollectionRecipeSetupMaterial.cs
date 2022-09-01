using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class WashingCollectionRecipeSetupMaterial
    {
        public long Id { get; set; }
        public long? RecipeProcessId { get; set; }
        public int? MaterialCategoryId { get; set; }
        public int? MaterialTypeId { get; set; }
        public int? ItemId { get; set; }
        public int? ItemUnitId { get; set; }
        public int? ItemPerUnitId { get; set; }
        public double? Quantity { get; set; }
        public double? TimeValue { get; set; }
        public double? HoldTime { get; set; }
        public double? Temperature { get; set; }
        public double? Rpm { get; set; }
    }
}
