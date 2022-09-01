using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class FsRejectionRepositoryReqSheetQty
    {
        public int Id { get; set; }
        public long StyleId { get; set; }
        public long SizeId { get; set; }
        public long ColorId { get; set; }
        public double Quantity { get; set; }
        public long? RejectionRepositoryId { get; set; }
        public long? ReqSheetMasterId { get; set; }
    }
}
