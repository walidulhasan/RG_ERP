using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblDyeingRollinspaction
    {
        public int Id { get; set; }
        public long? RollId { get; set; }
        public long? Lotid { get; set; }
        public int? DefectId { get; set; }
        public decimal? DefectValue { get; set; }
        public string Comment { get; set; }
        public DateTime? InspectionDate { get; set; }
        public string Remarks { get; set; }
        public int? Userid { get; set; }
        public decimal? Horizontal { get; set; }
        public decimal? Vertical { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Width { get; set; }
        public int? Gsm { get; set; }
        public long? Orderid { get; set; }
    }
}
