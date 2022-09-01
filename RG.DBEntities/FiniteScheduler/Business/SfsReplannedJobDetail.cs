using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsReplannedJobDetail
    {
        public long JobId { get; set; }
        public long SizeId { get; set; }
        public long ColorId { get; set; }
        public long? Balance { get; set; }
        public long ReplannedJobDetailId { get; set; }
    }
}
