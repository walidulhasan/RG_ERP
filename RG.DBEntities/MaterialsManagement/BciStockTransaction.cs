using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciStockTransaction
    {
        [Key]
        public long StockTransactionId { get; set; }
        public int DocumentTypeId { get; set; }
        public int DocumentNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime DocumentDate { get; set; }
        public int? BuyerId { get; set; }
        public int? OrderId { get; set; }
        public string Model { get; set; }
        public int Quantity { get; set; }
        public double? Rate { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int? BciCartonSetupMasterId { get; set; }
        public long? ModelId { get; set; }
    }
}
