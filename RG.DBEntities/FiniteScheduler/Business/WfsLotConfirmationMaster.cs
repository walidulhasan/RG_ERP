using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WfsLotConfirmationMaster
    {
        public long Id { get; set; }
        public string ConfirmationNo { get; set; }
        public DateTime? CreationDate { get; set; }
        public long? ProcessId { get; set; }
        public long? UserId { get; set; }
        public int? Status { get; set; }
        public string Comments { get; set; }
    }
}
