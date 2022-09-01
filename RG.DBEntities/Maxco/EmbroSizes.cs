using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class EmbroSizes
    {
        
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public int SelectedSizeRangeId { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }

        public virtual EmbroSpecification Object { get; set; }
    }
}
