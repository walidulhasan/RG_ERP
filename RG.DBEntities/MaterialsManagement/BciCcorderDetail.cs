using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciCcorderDetail
    {
        [Key]
        public long CcorderId { get; set; }
        public long StyleId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public long Quantity { get; set; }
        public byte Deleted { get; set; }
        public long? ComboDetailId { get; set; }
        public decimal Uid { get; set; }
    }
}
