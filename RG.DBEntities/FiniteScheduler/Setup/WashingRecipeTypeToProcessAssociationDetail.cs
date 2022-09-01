using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class WashingRecipeTypeToProcessAssociationDetail
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public int RecipeTypeId { get; set; }
        public int RecipeSubTypeId { get; set; }
        public int IsWetProcess { get; set; }
        public int ProcessCodeId { get; set; }
        public bool Deleted { get; set; }
    }
}
