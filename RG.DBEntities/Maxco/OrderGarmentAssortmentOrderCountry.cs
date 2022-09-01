using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class OrderGarmentAssortmentOrderCountry
    {
        public long Id { get; set; }
        public long? StyleId { get; set; }
        public long? CountryId { get; set; }
        public long? ColorId { get; set; }
        public string VariationColor { get; set; }
        public long? SizeId { get; set; }
        public long? NumberofGarments { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? Isedited { get; set; }
        public int? Version { get; set; }
        public int? FabricSet { get; set; }
        public long? Additional { get; set; }
    }
}
