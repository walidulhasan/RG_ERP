using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblMarkerInputConfirm
    {
        public long Id { get; set; }
        public long? CInputId { get; set; }
        public DateTime? RcvDate { get; set; }
        public long? Userid { get; set; }
        public long? Location { get; set; }
    }
}
