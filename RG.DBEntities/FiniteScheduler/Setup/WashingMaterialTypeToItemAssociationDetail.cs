using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class WashingMaterialTypeToItemAssociationDetail
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public int MaterialTypeId { get; set; }
        public int ItemId { get; set; }
        public bool Deleted { get; set; }
        public int? UserId { get; set; }
        public DateTime? Rdate { get; set; }
    }
}
