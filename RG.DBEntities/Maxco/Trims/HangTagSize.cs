using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class HangTagSize
    {
        public int Id { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public int SelectedSizeRangeId { get; set; }
        public int HangTagSpecificationId { get; set; }

        public virtual HangTagSpecification HangTagSpecification { get; set; }
    }
}
