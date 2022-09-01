using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class WashingSampleRecipeSetupRpmrange
    {
        public int Id { get; set; }
        public int RecipeMasterId { get; set; }
        public int ProcessId { get; set; }
        public bool IsWetProcess { get; set; }
        public int Sno { get; set; }
        public decimal TimeFrom { get; set; }
        public decimal TimeTo { get; set; }
        public int Rpm { get; set; }
        public bool Deleted { get; set; }
        public int? ProcessSequence { get; set; }
    }
}
