using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WfsConfirmationMaster
    {
        public long ConfirmationId { get; set; }
        public long JobId { get; set; }
        public DateTime ConfirmationDate { get; set; }
        public string Comments { get; set; }
    }
}
