using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblLoanToSupplierMaster
    {
        [Key]
        public long LoanId { get; set; }
        public string GatePassNo { get; set; }
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        public long SupplierId { get; set; }
        public long? CompanyId { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatorComments { get; set; }
        public double? TotalAmount { get; set; }
        public DateTime? GatePassDate { get; set; }
        public int? GatePassUserId { get; set; }
    }
}
