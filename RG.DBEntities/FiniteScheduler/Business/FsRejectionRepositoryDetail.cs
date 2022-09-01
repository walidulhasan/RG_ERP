using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class FsRejectionRepositoryDetail
    {
        public long RejectionRepositoryId { get; set; }
        public long AttributeInstanceId { get; set; }
        public long? PatternPieceId { get; set; }
        public int? BundleId { get; set; }
        public int PatternPieceQuantity { get; set; }
        public int WorkCenterId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public long RejectionRepositoryDetailId { get; set; }
        public int? SerialNo { get; set; }
        public int? RejectedBy { get; set; }
        public int? Status { get; set; }

        public virtual FsRejectionRepository RejectionRepository { get; set; }
    }
}
