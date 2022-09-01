using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricTransactionLog
    {
        public int Id { get; set; }
        public long StyleId { get; set; }
        public short TransactionId { get; set; }
        public int UserId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int? FabricTrimId { get; set; }
        public bool? IsShell { get; set; }
        public string Ipaddress { get; set; }
        public long? ObjectId { get; set; }
    }
}
