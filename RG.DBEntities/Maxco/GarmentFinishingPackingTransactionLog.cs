using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class GarmentFinishingPackingTransactionLog
    {
        public int Id { get; set; }
        public long StyleId { get; set; }
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool? IsFinishing { get; set; }
        public bool? IsPacking { get; set; }
    }
}
