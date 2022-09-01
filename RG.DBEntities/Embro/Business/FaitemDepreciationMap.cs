using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class FaitemDepreciationMap
    {
        public int RelationId { get; set; }
        public int ItemId { get; set; }
        public string DepreciationType { get; set; }
        public int AccumulatedDepreciationAccount { get; set; }
        public int DepreciationExpenseAccount { get; set; }
    }
}
