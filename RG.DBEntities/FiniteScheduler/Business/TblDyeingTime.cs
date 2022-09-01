using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblDyeingTime
    {
        public int Id { get; set; }
        public long? LotId { get; set; }
        public int? McNo { get; set; }
        public DateTime? Creationdate { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? UserId { get; set; }
        public string Comment { get; set; }
        public int? Category { get; set; }
        public int? Type { get; set; }
        public int? LoadStatus { get; set; }
        public DateTime? EndTimeEntry { get; set; }
    }
}
