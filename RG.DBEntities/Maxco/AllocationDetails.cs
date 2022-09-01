using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class AllocationDetails
    {
        public int Id { get; set; }
        public int AllocationId { get; set; }
        public int? IsCircular { get; set; }
        public int VariationId { get; set; }
        public int? AllocationQuantity { get; set; }
        public int? TrimId { get; set; }
        public int? PantoneNo { get; set; }
        public int? ContrastVariationId { get; set; }
        public int? ContrastPantoneNo { get; set; }
        public int? FabricId { get; set; }

        public virtual AllocationMaster Allocation { get; set; }
    }
}
