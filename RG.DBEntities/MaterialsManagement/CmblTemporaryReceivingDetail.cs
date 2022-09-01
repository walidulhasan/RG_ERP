using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblTemporaryReceivingDetail
    {
        [Key]
        public long Trdid { get; set; }
        public double Quantity { get; set; }
        public int Trid { get; set; }
        public int StoreId { get; set; }
        public int LocationId { get; set; }
        public double Pobalance { get; set; }
        public int ItemId { get; set; }
        public int PoitemId { get; set; }
        public double? Rate { get; set; }

        public virtual CmblTemporaryReceiving Tr { get; set; }
    }
}
