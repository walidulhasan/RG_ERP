using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CcshipmentStatusView
    {
        [Key]
        public int CustomerId { get; set; }
        public int DestinationId { get; set; }
        public long? OrderDeliveryId { get; set; }
        public string CustomerCode { get; set; }
        public string DestinationCode { get; set; }
        public string Delivery { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public long? OrderQuantity { get; set; }
        public int ShippedQuantity { get; set; }
    }
}
