using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblDyeingWG
    {
        public int DyeingWgId { get; set; }
        public long? Rollid { get; set; }
        public decimal? Width { get; set; }
        public decimal? Gsm { get; set; }
        public long? UserId { get; set; }
        public DateTime? Creationdate { get; set; }
        public int? Entrytime { get; set; }
        public long? Lotid { get; set; }
        public string Comment { get; set; }
        public decimal? Width1 { get; set; }
        public decimal? Width2 { get; set; }
    }
}
