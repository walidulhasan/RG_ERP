using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class ModelEmbroCost
    {
        public int Id { get; set; }
        public byte? TrimId { get; set; }
        public string ImageCode { get; set; }
        public double? Consumption { get; set; }
        public double? UnitCost { get; set; }
        public int StyleId { get; set; }
        public int CollectionId { get; set; }
        public int? VersionId { get; set; }
        public bool? IsHandEmbro { get; set; }
        public long? ImageId { get; set; }

        public virtual ModelCosting ModelCosting { get; set; }
    }
}
