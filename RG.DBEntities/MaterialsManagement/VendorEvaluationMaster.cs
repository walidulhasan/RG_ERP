using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class VendorEvaluationMaster
    {
        public int Id { get; set; }
        public string EvaluationCriteria { get; set; }
        public int? User { get; set; }
        public DateTime? Date { get; set; }
        public int? Sequance { get; set; }
    }
}
