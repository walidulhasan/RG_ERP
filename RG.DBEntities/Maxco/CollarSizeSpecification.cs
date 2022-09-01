using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class CollarSizeSpecification
    {
        public int CollarSpecificationId { get; set; }
        public long SelectedSizeRangeId { get; set; }
        public double Size { get; set; }
        public double Width { get; set; }
        public int Id { get; set; }

        public virtual CollarSpecification CollarSpecification { get; set; }
        public virtual SelectedGarmentSizeRange SelectedSizeRange { get; set; }
    }
}
