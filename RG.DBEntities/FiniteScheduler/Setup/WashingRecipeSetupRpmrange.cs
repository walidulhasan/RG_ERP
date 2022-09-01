using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class WashingRecipeSetupRpmrange
    {
        public long Id { get; set; }
        public long RecipeProcessId { get; set; }
        public int Sno { get; set; }
        public double TimeFrom { get; set; }
        public double TimeTo { get; set; }
        public double Rpm { get; set; }
    }
}
