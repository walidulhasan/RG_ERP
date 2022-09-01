using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class ImportUsdata
    {
        [Key]
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string DestinationCode { get; set; }
        public DateTime? OrderDate { get; set; }
        public string IdNumer { get; set; }
        public string StyleCode { get; set; }
        public string Colour { get; set; }
        public string StyleDescription { get; set; }
        public string Season { get; set; }
        public string Brand { get; set; }
        public string DeliveryTheme { get; set; }
        public string Size { get; set; }
        public double? SoldQnt { get; set; }
        public long? StyleId { get; set; }
        public long? ColorId { get; set; }
        public long? SizeId { get; set; }
        public long? StyleId1 { get; set; }
        public long? CustomerId { get; set; }
        public long? DestinationId { get; set; }
        public string CustomerCode1 { get; set; }
    }
}
