using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblLoanItem
    {
        [Key]
        public long LoanItemId { get; set; }
        public long ItemId { get; set; }
        public long LoanId { get; set; }
        public int UnitId { get; set; }
        public long RequisitionDetailId { get; set; }
        public double Quantity { get; set; }
        public double Rate { get; set; }
        public double Balance { get; set; }
        public string Remarks { get; set; }
        public int? CurrencyId { get; set; }
        public double? ConversionRate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? DeliveryPoint { get; set; }
    }
}
