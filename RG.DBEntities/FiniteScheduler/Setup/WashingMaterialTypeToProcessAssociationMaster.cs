using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class WashingMaterialTypeToProcessAssociationMaster
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public bool? IsWetProcess { get; set; }
        public byte? FabricCategoryId { get; set; }
        public int? ProcessCodeId { get; set; }
        public bool Deleted { get; set; }
    }
}
