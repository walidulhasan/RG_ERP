using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class UsdataToDelete
    {
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string DestinationCode { get; set; }
        public DateTime? OrderDate { get; set; }
        public string IdNumer { get; set; }
        public string OrderNo { get; set; }
        public string StyleCode { get; set; }
        public double? Colour { get; set; }
        public string StyleDescription { get; set; }
        public string Season { get; set; }
        public string Brand { get; set; }
        public string DeliveryTheme { get; set; }
        public string Size { get; set; }
        public double? SoldQnt { get; set; }
    }
}
