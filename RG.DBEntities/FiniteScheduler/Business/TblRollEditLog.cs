using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblRollEditLog
    {
        public int RollEditId { get; set; }
        public long? Lotid { get; set; }
        public long? Rollid { get; set; }
        public decimal? Rollwidth { get; set; }
        public decimal? Rollweight { get; set; }
        public long? User { get; set; }
        public DateTime? Creationdate { get; set; }
        public decimal? Gsm { get; set; }
        public decimal? Dwidth { get; set; }
        public decimal? Dgsm { get; set; }
        public decimal? Dweight { get; set; }
    }
}
