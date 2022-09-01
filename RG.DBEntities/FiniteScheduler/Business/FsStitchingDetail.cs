using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class FsStitchingDetail
    {
        public long Id { get; set; }
        public long? MasterId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public long Quantity { get; set; }
        public long StyleId { get; set; }
        public bool? IsBarCode { get; set; }

        public virtual FsStitchingMaster Master { get; set; }
    }
}
