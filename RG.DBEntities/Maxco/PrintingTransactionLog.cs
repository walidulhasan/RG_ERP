using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class PrintingTransactionLog
    {
        public int Id { get; set; }
        public int StyleId { get; set; }
        public byte TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool IsPrinting { get; set; }
        public int UserId { get; set; }
        public bool? IsGeredefinition { get; set; }
        public string Ipaddress { get; set; }
        public long? ObjectId { get; set; }
    }
}
