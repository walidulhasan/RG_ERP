using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class WashingSampleRecipeSetupMaster
    {
        public int RecipeMasterId { get; set; }
        public string RecipeName { get; set; }
        public int RecipeTypeId { get; set; }
        public int RecipeSubTypeId { get; set; }
        public byte FabricCategoryId { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string Comments { get; set; }
        public bool Deleted { get; set; }
        public long? ModelId { get; set; }
    }
}
