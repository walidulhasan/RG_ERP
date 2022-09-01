using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class FurYarnSpecificationColor
    {
        public int Id { get; set; }
        public int YarnSpecificationId { get; set; }
        public long ColorSetId { get; set; }
        public string PantoneNo { get; set; }
        public int? VendorColorId { get; set; }

        public virtual FurYarnSpecification YarnSpecification { get; set; }
    }
}
