using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class BundleTransaction
    {
        public long BundleId { get; set; }
        public DateTime Bdate { get; set; }
        public int BundleStatusId { get; set; }
        public int UserId { get; set; }
    }
}
