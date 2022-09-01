using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblCuttingWeight
    {
        public long Id { get; set; }
        public long? MarkerId { get; set; }
        public decimal? CuttingWeight { get; set; }
        public string Comment { get; set; }
        public DateTime? Creationdate { get; set; }
        public long? Userid { get; set; }
    }
}
