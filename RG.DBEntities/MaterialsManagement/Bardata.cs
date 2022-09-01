using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class Bardata
    {
        public string Status { get; set; }
        public string CustomerCode { get; set; }
        public string DestinationCode { get; set; }
        public DateTime? OrderDate { get; set; }
        public string StyleCode { get; set; }
        public string Colour { get; set; }
        public string StyleDescription { get; set; }
        public string Brand { get; set; }
        public string Season { get; set; }
        public string Theme { get; set; }
        public string Size { get; set; }
        public double? OrderQuantity { get; set; }
        public string F13 { get; set; }
        public string F14 { get; set; }
        public byte? Type { get; set; }
        public long? StyleId { get; set; }
        public long? ColorId { get; set; }
        public long? SizeId { get; set; }
        public long? StyleId1 { get; set; }
        public long? CustomerId { get; set; }
        public long? DestinationId { get; set; }
    }
}
