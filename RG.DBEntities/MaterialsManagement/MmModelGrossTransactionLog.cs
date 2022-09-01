using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmModelGrossTransactionLog
    {
        public long Id { get; set; }
        public long StyleId { get; set; }
        public int TransactionId { get; set; }
        public string UserId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Ipaddress { get; set; }
    }
}
