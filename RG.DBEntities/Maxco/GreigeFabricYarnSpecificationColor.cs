using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class GreigeFabricYarnSpecificationColor
    {
        public int Id { get; set; }
        public long GreigeFabricYarnSpecificationId { get; set; }
        public long? ColorsetId { get; set; }
        public string PantoneNo { get; set; }
        public int? VendorColorId { get; set; }
        public bool? IsSelected { get; set; }
        public byte? ColorIndex { get; set; }
        public int? PalleteTypeId { get; set; }
        public string ColorName { get; set; }
        public int? Utilization { get; set; }
    }
}
