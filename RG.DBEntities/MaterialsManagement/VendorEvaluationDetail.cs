using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class VendorEvaluationDetail
    {
        public int Id { get; set; }
        public int? EvaluationMasterId { get; set; }
        public string CriteriaDescription { get; set; }
        public long? User { get; set; }
        public DateTime? Date { get; set; }
        public int? Achievable { get; set; }
    }
}
