using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WashingRecipeStageProcessAssociation
    {
        public long Id { get; set; }
        public long ParentProcessId { get; set; }
        public long ChildProcessId { get; set; }
        public byte RecipeStageId { get; set; }
        public DateTime? Rdate { get; set; }
    }
}
