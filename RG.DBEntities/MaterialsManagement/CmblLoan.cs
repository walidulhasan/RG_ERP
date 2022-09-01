using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblLoan
    {
        [Key]
        public long LoanId { get; set; }
        public long LoanNo { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public int UserId { get; set; }
        public int? SupplierId { get; set; }
        public string LoanComments { get; set; }
        public int? CompanyId { get; set; }
        public int? ApprovedBy { get; set; }
        public string MainComments { get; set; }
        public double? TotalValue { get; set; }
        public int? LocationSelStatus { get; set; }
        public int? DateSelStatus { get; set; }
        public int? PriceSelStatus { get; set; }
        public int LoanStatus { get; set; }
    }
}
