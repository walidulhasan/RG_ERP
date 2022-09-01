using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WashingRecipeToStyleAssociation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int? UserId { get; set; }
        public int StyleId { get; set; }
        public int RecipeMasterId { get; set; }
        public bool Deleted { get; set; }
    }
}
