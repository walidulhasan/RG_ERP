using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsPickListDetail
    {
        public long PickListDetailId { get; set; }
        public long PickListId { get; set; }
        public long SizeId { get; set; }
        public long ColorId { get; set; }
        public long Quantity { get; set; }

        public virtual SfsPickListMaster PickList { get; set; }
    }
}
