using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DyedFrsagainstRollAssignmentTransactions
    {
        [Key]
        public long TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public long Fid { get; set; }
        public long DyedStockId { get; set; }
        public double Quantity { get; set; }
    }
}
