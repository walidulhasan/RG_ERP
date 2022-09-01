using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class EmbroideryReceivingDetail
    {
        public int EmrbroideryReceivingDetailId { get; set; }
        public int EmbroideryMasterId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int AvailableQty { get; set; }
        public int ReceivedQty { get; set; }

        public virtual EmbroideryReceivingMaster EmbroideryMaster { get; set; }
    }
}
