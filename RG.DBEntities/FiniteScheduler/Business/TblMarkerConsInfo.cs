using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblMarkerConsInfo
    {
        public int MarkerConsId { get; set; }
        public int? UserId { get; set; }
        public DateTime? HDate { get; set; }
        public int? Companyid { get; set; }
        public int? Buyerid { get; set; }
        public decimal? CadConsDz { get; set; }
        public decimal? CosConsDz { get; set; }
        public decimal? FabCostYrd { get; set; }
        public long? OrderId { get; set; }
        public long? StyleId { get; set; }
    }
}
