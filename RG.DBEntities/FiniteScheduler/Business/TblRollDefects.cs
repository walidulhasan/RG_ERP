using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblRollDefects
    {
        public long Id { get; set; }
        public long? RollId { get; set; }
        public int? DefectId { get; set; }
        public decimal? DefectValue { get; set; }
        public string Comment { get; set; }
        public decimal? Score { get; set; }
        public DateTime? InspectionDate { get; set; }
        public int? Guage { get; set; }
        public string Sl { get; set; }
        public int? Rpm { get; set; }
        public int? Feeder { get; set; }
        public int? Ycount { get; set; }
        public int? Mdia { get; set; }
        public int? MacNo { get; set; }
        public int? YType { get; set; }
        public int? YColor { get; set; }
        public long? UserId { get; set; }
    }
}
