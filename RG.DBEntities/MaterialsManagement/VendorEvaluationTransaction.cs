using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class VendorEvaluationTransaction
    {
        public long Id { get; set; }
        public long? SupplierId { get; set; }
        public int? EvaluationDetailId { get; set; }
        public double? EvaluationScore { get; set; }
        public DateTime EvaluationDate { get; set; }
        public long? UserId { get; set; }
        public long? CompanyId { get; set; }
        public long? ItemId { get; set; }
        public DateTime? Creationdate { get; set; }
    }
}
