using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WashingLotMaster
    {
        public int LotMasterId { get; set; }
        public string LotNo { get; set; }
        public int? RecipeId { get; set; }
        public int? UserId { get; set; }
        public string Comments { get; set; }
        public DateTime Date { get; set; }
        public bool Deleted { get; set; }
        public int? ParentRecipeId { get; set; }
        public byte? IsFinalized { get; set; }
        public long? RequisitionId { get; set; }
    }
}
