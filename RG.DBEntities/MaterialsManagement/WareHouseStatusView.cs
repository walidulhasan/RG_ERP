using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class WareHouseStatusView
    {
        public int? CartonNo { get; set; }
        public string CartonType { get; set; }
        public DateTime Date { get; set; }
        public int CartonQuality { get; set; }
        public string UserName { get; set; }
        public string Customer { get; set; }
        public string Delivery { get; set; }
        public string Destination { get; set; }
        public string OrderNo { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int? Quantity { get; set; }
    }
}
