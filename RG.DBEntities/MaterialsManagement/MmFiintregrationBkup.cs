using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmFiintregrationBkup
    {
        public int Id { get; set; }
        public int? DocumentTypeId { get; set; }
        public int? DocumentId { get; set; }
        public string DocumentNo { get; set; }
        public int? VouchareId { get; set; }
        public string VouchareNo { get; set; }
        public int? CompanyId { get; set; }
        public int? Status { get; set; }
        public DateTime? TransactionDate { get; set; }
    }
}
