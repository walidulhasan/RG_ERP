using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WashingRecipeOptionsToProcessAssociationMaster
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool Deleted { get; set; }
        public DateTime Date { get; set; }
    }
}
