using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblDyeingRolldefects
    {
        public int Id { get; set; }
        public long? RollId { get; set; }
        public long? Lotid { get; set; }
        public int? DefectId { get; set; }
        public decimal? DefectValue { get; set; }
        public byte[] Comment { get; set; }
        public DateTime? InspectionDate { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Width { get; set; }
        public int? Gsm { get; set; }
        public decimal? Width2 { get; set; }
        public decimal? Width3 { get; set; }
        public string Remarks { get; set; }
        public decimal? DefectValueie { get; set; }
        public int? Userid { get; set; }
    }
}
