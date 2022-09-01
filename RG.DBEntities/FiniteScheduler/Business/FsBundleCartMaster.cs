using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class FsBundleCartMaster
    {
        public FsBundleCartMaster()
        {
            FsBundleCartDetail = new HashSet<FsBundleCartDetail>();
        }

        public long CartMasterId { get; set; }
        public long StyleId { get; set; }
        public DateTime Date { get; set; }
        public byte? Status { get; set; }

        public virtual ICollection<FsBundleCartDetail> FsBundleCartDetail { get; set; }
    }
}
