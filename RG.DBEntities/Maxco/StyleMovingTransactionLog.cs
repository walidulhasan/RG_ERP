using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class StyleMovingTransactionLog
    {
        public int Id { get; set; }
        public long StyleId { get; set; }
        public bool Status { get; set; }
        public DateTime TransactionDate { get; set; }
        public int UserId { get; set; }
    }
}
