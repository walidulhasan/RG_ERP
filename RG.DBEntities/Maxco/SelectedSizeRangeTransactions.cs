using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class SelectedSizeRangeTransactions
    {
        public int Id { get; set; }
        public byte TransactionTypeId { get; set; }
        public long SelectedGarmentSizeSrangeId { get; set; }
        public short UserId { get; set; }
        public DateTime DateTime { get; set; }
        public int? StyleId { get; set; }
    }
}
