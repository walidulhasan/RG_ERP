using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciSharingDetail
    {
        [Key]
        public long DetailId { get; set; }
        public long SharingId { get; set; }
        public long CustomerId { get; set; }
        public long DestinationId { get; set; }
        public long OrderDeliveryId { get; set; }
        public long OrderId { get; set; }
        public long StyleId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public long SharedQty { get; set; }
        public int Status { get; set; }

        public virtual BciSharingMain Sharing { get; set; }
    }
}
