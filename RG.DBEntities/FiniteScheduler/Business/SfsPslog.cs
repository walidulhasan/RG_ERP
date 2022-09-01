using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsPslog
    {
        public int Id { get; set; }
        public int? LineId { get; set; }
        public int? UserId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public short? TransactionId { get; set; }
    }
}
