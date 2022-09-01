using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblAgencyTransactions
    {
        public long TransCode { get; set; }
        public long TransId { get; set; }
        public double? Quantity { get; set; }
        public DateTime TransDate { get; set; }
        public int? DocumentTypeId { get; set; }
        public int? CommentsId { get; set; }
    }
}
