using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class ExpPackingList
    {
        [Key]
        public string InvoiceNo { get; set; }
        public string ContainerNo { get; set; }
        public string CustomerCode { get; set; }
        public string DestinationCode { get; set; }
        public string OrderDelivery { get; set; }
        public long CartonNo { get; set; }
        public string OrderNo { get; set; }
        public string Style { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
    }
}
