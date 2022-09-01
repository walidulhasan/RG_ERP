using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class AllocationRatios
    {
        public int Id { get; set; }
        public int AllocationId { get; set; }
        public int? SizeSetId { get; set; }
        public int? Ratio { get; set; }
        public int? Quantity { get; set; }
        public string SizeDescription { get; set; }

        public virtual AllocationMaster Allocation { get; set; }
    }
}
