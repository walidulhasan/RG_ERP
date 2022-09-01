using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ZipSliderImageSetupDetail
    {
        public short Id { get; set; }
        public short? ImageId { get; set; }
        public double ZipLength { get; set; }
        public short VendorId { get; set; }
        public string Code { get; set; }
        public int? CollectionId { get; set; }
        public double? Price { get; set; }
        public bool? IsPriceInsert { get; set; }
        public long? TrimId { get; set; }
        public double? Fob { get; set; }
        public double? Frieght { get; set; }
        public double? Duty { get; set; }
        public double? Clrtotal { get; set; }
    }
}
