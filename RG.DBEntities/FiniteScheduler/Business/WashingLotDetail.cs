using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WashingLotDetail
    {
        public int Id { get; set; }
        public int LotMasterId { get; set; }
        public int? ModelId { get; set; }
        public long? ColorId { get; set; }
        public double? PerGarmentWeight { get; set; }
        public int? TotalGarments { get; set; }
        public double? TotalWeight { get; set; }
    }
}
