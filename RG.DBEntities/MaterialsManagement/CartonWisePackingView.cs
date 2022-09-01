using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CartonWisePackingView
    {
        public DateTime TransactionDate { get; set; }
        [Key]
        public string CustomerCode { get; set; }
        public string DestinationCode { get; set; }
        public string Delivery { get; set; }
        public int? CartonNo { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
    }
}
