using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class PrintWorkOrder
    {
        public int? Id { get; set; }
        public string BuyerName { get; set; }
        public string OrderNumber { get; set; }
        public string FabricComposition { get; set; }
        public string Color { get; set; }
        public string PrintType { get; set; }
        public int? PrintQty { get; set; }
        public int? MeasurementUnit { get; set; }
        public decimal? PrintRate { get; set; }
        public string SupplierName { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }
}
