using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class WoWorkOrderDetails
    {
        public int Id { get; set; }
        public double Quantity { get; set; }
        public string DeliveryDate { get; set; }
        public string Remarks { get; set; }
        public int? WomasterId { get; set; }
        public int? DeliveryPointId { get; set; }
        public double? Rate { get; set; }
        public double? Balance { get; set; }
        public double? ConvPrice { get; set; }
        public double? CurrencyRate { get; set; }
        public int? CurrencyId { get; set; }
    }
}
