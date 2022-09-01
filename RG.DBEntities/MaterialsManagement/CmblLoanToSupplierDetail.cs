using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblLoanToSupplierDetail
    {
        [Key]
        public long LoanDetailId { get; set; }
        public long LoanId { get; set; }
        public long ItemId { get; set; }
        public int UserSelectedUnitId { get; set; }
        public double LoanQuantity { get; set; }
        public double? Balance { get; set; }
        public double? Rate { get; set; }
        public long? StoreLocationId { get; set; }
        public string StoreLocationName { get; set; }
    }
}
