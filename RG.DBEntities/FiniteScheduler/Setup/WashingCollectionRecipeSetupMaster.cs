using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class WashingCollectionRecipeSetupMaster
    {
        public int RecipeMasterId { get; set; }
        public string RecipeName { get; set; }
        public int RecipeTypeId { get; set; }
        public int RecipeSubTypeId { get; set; }
        public byte FabricCategoryId { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Deleted { get; set; }
        public long? CollectionId { get; set; }
        public long? ModelId { get; set; }
        public long? FabricSpecificationColorId { get; set; }
        public int? ParentRecipeId { get; set; }
        public byte? RecipeStageId { get; set; }
        public string PantoneNo { get; set; }
        public byte? Approved { get; set; }
        public long? NoOfPieces { get; set; }
        public short? UserId { get; set; }
        public short? ApprovedBy { get; set; }
        public DateTime? ApprovedOn { get; set; }
    }
}
