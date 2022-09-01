using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class LabelSize
    {
        public int ID { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public long SelectedSizeRangeID { get; set; }
        public int LabelSpecificationID { get; set; }

       // public virtual SelectedGarmentSizeRange SelectedSizeRange { get; set; }
    }
}
