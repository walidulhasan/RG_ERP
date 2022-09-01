using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class AdvancePayment
    {
        public long ID { get; set; }
        public string POID { get; set; }
        public decimal? Deduction { get; set; }
        public long? Voucherid { get; set; }
        public long? SupplierID { get; set; }
        public string PoNumber { get; set; }
        public int? StoreID { get; set; }
    }
}
