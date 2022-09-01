using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciReceivingDetail
    {
        [Key]
        public long ReceivingId { get; set; }
        public long StyleId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public long Quantity { get; set; }
        public byte Deleted { get; set; }

        public virtual BciReceiving Receiving { get; set; }
    }
}
