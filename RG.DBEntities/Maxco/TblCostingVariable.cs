using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TblCostingVariable
    {
        public int Id { get; set; }
        public int CostingVariableId { get; set; }
        public string CostingVariableDesc { get; set; }
    }
}
