using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TrimTransactionLog
    {
        public int Id { get; set; }
        public long StyleId { get; set; }
        public byte TrimId { get; set; }
        public short UserId { get; set; }
        public byte TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Ipaddress { get; set; }
        public long? ObjectId { get; set; }
    }
}
