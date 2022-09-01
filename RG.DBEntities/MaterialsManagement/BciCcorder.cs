using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciCcorder
    {
        [Key]
        public long CcorderId { get; set; }
        public DateTime? CreationDate { get; set; }
        public long CustomerId { get; set; }
        public long DestinationId { get; set; }
        public byte Deleted { get; set; }
        public int UserId { get; set; }
        public DateTime CorderDate { get; set; }
        public long OrderDeliveryId { get; set; }
    }
}
