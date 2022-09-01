using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TblCostingVariableValues
    {
        public int Id { get; set; }
        public int? CostingMonth { get; set; }
        public int? CostingYear { get; set; }
        public long? CostingCompanyId { get; set; }
        public int? CostingProfitCenter { get; set; }
        public int? CostingVariableId { get; set; }
        public double? CostingValue { get; set; }
    }
}
