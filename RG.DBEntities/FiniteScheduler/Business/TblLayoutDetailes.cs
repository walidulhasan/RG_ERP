using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblLayoutDetailes
    {
        public int Id { get; set; }
        public long? Stocktransationid { get; set; }
        public string LineSlNo { get; set; }
        public long? EmpId { get; set; }
        public decimal? Smv { get; set; }
        public long? Processid { get; set; }
        public long? TargetQty { get; set; }
        public long? MachineId { get; set; }
        public DateTime? Creationdate { get; set; }
    }
}
