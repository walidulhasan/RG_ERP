using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnReceivingWithoutPomaster
    {
        public long YarnRecWopoid { get; set; }
        public string Pono { get; set; }
        public long SupplierId { get; set; }
        public DateTime Podate { get; set; }
        public long BrokerId { get; set; }
        public long StoreId { get; set; }
        public long CartageId { get; set; }
        public string DeliveryChallanNo { get; set; }
        public DateTime DeliveryChallanDate { get; set; }
        public string DeliveryPerson { get; set; }
        public string Remarks { get; set; }
        public string Reference { get; set; }
        public long? ProgramId { get; set; }
        public int? OrderId { get; set; }
        public string OrderNo { get; set; }
    }
}
