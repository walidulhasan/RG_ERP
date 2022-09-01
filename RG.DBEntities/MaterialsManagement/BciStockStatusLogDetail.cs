using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciStockStatusLogDetail
    {
        [Key]
        public long RunId { get; set; }
        public long OrderId { get; set; }
        public long StyleId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public long ReceivedQuantity { get; set; }
        public long? PackedQuantity { get; set; }
        public byte Deleted { get; set; }

        public virtual BciStockStatusLog Run { get; set; }
    }
}
