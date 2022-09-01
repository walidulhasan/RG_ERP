using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class WashingMaterialTypeSetup
    {
        public long MaterialTypeId { get; set; }
        public string MaterialTypeName { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public bool Deleted { get; set; }
    }
}
