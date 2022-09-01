using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class SupplierBankInfo
    {
        public int ID { get; set; }
        public decimal? SupplierID { get; set; }
        public string BankName { get; set; }
        public string Branch { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingNo { get; set; }
        public string SwiftNo { get; set; }
    }
}
