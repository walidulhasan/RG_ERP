using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CottonContractItem
    {
        public long Id { get; set; }
        public long ContractId { get; set; }
        public long AttributeInstanceId { get; set; }
        public int UnitId { get; set; }
        public long RequisitionDetailId { get; set; }
        public double Quantity { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double Rate { get; set; }
        public double? Balance { get; set; }
        public string Remarks { get; set; }
        public int DeliveryPoint { get; set; }
    }
}
