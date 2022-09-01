using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class IcScrapSalesGatePassDetail
    {
        public long Id { get; set; }
        public string ItemName { get; set; }
        public double Quantity { get; set; }
        public int UnitId { get; set; }
        public double? FirstWeight { get; set; }
        public double? SecondWeight { get; set; }
        public string Remarks { get; set; }
        public long? ScrapSalesGatePassId { get; set; }
    }
}
