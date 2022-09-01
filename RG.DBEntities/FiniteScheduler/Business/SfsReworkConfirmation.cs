using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsReworkConfirmation
    {
        public long ConfirmationId { get; set; }
        public long JobId { get; set; }
        public long StyleId { get; set; }
        public long Id { get; set; }
    }
}
