using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class FsRejectionRepository
    {
        public FsRejectionRepository()
        {
            FsRejectionRepositoryDetail = new HashSet<FsRejectionRepositoryDetail>();
        }

        public long RejectionRepositoryId { get; set; }
        public long StyleId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public long? Quantity { get; set; }
        public int Status { get; set; }
        public long? Balance { get; set; }
        public int? ChallanId { get; set; }

        public virtual ICollection<FsRejectionRepositoryDetail> FsRejectionRepositoryDetail { get; set; }
    }
}
