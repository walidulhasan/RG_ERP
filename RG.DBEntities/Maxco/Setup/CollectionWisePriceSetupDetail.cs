using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class CollectionWisePriceSetupDetail
    {
        public int Id { get; set; }
        public long ZipLength { get; set; }
        public int CollectionId { get; set; }
        public int ItemSetupId { get; set; }
        public double Price { get; set; }
        public double? SimulatedPrice { get; set; }
        public byte? TrimId { get; set; }
        public double? Fob { get; set; }
        public double? Frieght { get; set; }
        public double? Duty { get; set; }
        public double? Clrtotal { get; set; }
        public int? VendorId { get; set; }
    }
}
