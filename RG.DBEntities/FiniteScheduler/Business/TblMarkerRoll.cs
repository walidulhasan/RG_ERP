using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblMarkerRoll
    {
        public int Id { get; set; }
        public int? Rollid { get; set; }
        public int? Lotid { get; set; }
        public int? Orderid { get; set; }
        public int? PantonId { get; set; }
        public int? DLayer { get; set; }
        public int? MLayer { get; set; }
        public decimal? SpreadingWastage { get; set; }
        public decimal? Leftover { get; set; }
        public string SpreadingTable { get; set; }
        public DateTime? SpreadingDate { get; set; }
        public int? StocktransationId { get; set; }
        public int? Width { get; set; }
        public int? Rgsm { get; set; }
        public decimal? Rweight { get; set; }
        public decimal? Rlength { get; set; }
        public string Fstatus { get; set; }
    }
}
