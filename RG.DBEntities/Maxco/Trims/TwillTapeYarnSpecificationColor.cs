using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class TwillTapeYarnSpecificationColor
    {
        public int Id { get; set; }
        public int YarnSpecificationId { get; set; }
        public long ColorSetId { get; set; }
        public string PantoneNo { get; set; }
        public int? VendorColorId { get; set; }

        public virtual TwillTapeYarnSpecification YarnSpecification { get; set; }
    }
}
