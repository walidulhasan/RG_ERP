using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ZipLength
    {
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public int SelectedSizeRangeId { get; set; }
        public double? Length { get; set; }

        public virtual ZipSpecification Object { get; set; }
    }
}
