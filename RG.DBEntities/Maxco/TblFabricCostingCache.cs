using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TblFabricCostingCache
    {
        public int Id { get; set; }
        public long? StyleId { get; set; }
        public long? VersionId { get; set; }
        public decimal TotalYarnRate { get; set; }
        public decimal FinishFabricCost { get; set; }
        public decimal GreigeFabricCost { get; set; }
        public decimal? KnittingRate { get; set; }
    }
}
