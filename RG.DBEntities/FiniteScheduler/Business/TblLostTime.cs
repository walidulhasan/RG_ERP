using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblLostTime
    {
        public long Id { get; set; }
        public int? LostTypeId { get; set; }
        public long? LostTime { get; set; }
        public DateTime? InputDate { get; set; }
        public DateTime? Date { get; set; }
        public string Shift { get; set; }
        public long? UserId { get; set; }
        public byte[] Comment { get; set; }
        public int? McNo { get; set; }
        public int? ShiftTime { get; set; }
        public string Remarks { get; set; }
    }
}
