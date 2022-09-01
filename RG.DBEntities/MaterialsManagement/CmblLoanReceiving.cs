using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblLoanReceiving
    {
        [Key]
        public int LoanRecId { get; set; }
        public DateTime DocumentDate { get; set; }
        public long SupplierId { get; set; }
        public long LoanId { get; set; }
        public int UserId { get; set; }
        public long CompanyId { get; set; }
        public string Deleted { get; set; }
        public long? LoanRecNo { get; set; }
        public string Challano { get; set; }
        public DateTime? ChallanDate { get; set; }
    }
}
