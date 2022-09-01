using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class EmbroPrintApproveTransactionLog
    {
        public int Id { get; set; }
        public long StyleId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int UserId { get; set; }
        public bool IsEmbro { get; set; }
        public bool IsPrinting { get; set; }
    }
}
