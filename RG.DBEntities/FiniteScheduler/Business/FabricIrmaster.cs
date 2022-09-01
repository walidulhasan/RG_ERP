using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class FabricIrmaster
    {
        public FabricIrmaster()
        {
            FabricIrdetail = new HashSet<FabricIrdetail>();
        }

        public int FabricIrmasterId { get; set; }
        public DateTime Dated { get; set; }
        public int UserId { get; set; }
        public string Comments { get; set; }
        public int JobId { get; set; }
        public int StockId { get; set; }
        public int PickListParent { get; set; }
        public int DocumentTypeId { get; set; }

        public virtual ICollection<FabricIrdetail> FabricIrdetail { get; set; }
    }
}
