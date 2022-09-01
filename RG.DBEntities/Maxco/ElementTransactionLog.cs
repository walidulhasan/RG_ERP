using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class ElementTransactionLog
    {
        public int Id { get; set; }
        public int StyleId { get; set; }
        public byte ElementId { get; set; }
        public short UserId { get; set; }
        public byte TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
