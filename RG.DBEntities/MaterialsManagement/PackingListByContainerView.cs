using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class PackingListByContainerView
    {
        public string InvoiceNo { get; set; }
        public string ContainerNo { get; set; }
        public string CustomerCode { get; set; }
        public string DestinationCode { get; set; }
        public string Delivery { get; set; }
        public int? CartonNo { get; set; }
        public string OrderNo { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int? Quantity { get; set; }
    }
}
