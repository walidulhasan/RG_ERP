using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class ModelOtherFabricCosting
    {
        public int Id { get; set; }
        public int? FabricId { get; set; }
        public int? CategoryId { get; set; }
        public string Description { get; set; }
        public double? Area { get; set; }
        public double? Rate { get; set; }
        public double? Cost { get; set; }
        public int? StyleId { get; set; }
        public int? CollectionId { get; set; }
        public int? VersionId { get; set; }
        public int? VendorId { get; set; }
        public string VendorName { get; set; }
        public string FabricCode { get; set; }
        public int? FabricCodeId { get; set; }

        public virtual ModelCosting Version { get; set; }
    }
}
