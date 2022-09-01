using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class WashingRecipeSetupMaterialSubstitution
    {
        public long Id { get; set; }
        public long? RecipeMaterialId { get; set; }
        public int? MaterialCategoryId { get; set; }
        public int? MaterialTypeId { get; set; }
        public int? ItemId { get; set; }
        public int? ItemUnitId { get; set; }
        public int? ItemPerUnitId { get; set; }
        public double? Quantity { get; set; }
        public int? UserId { get; set; }
        public DateTime? Rdate { get; set; }
    }
}
