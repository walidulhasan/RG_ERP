using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MM_FIIntregration
    {
        public int ID { get; set; }
        public int? DocumentTypeID { get; set; }
        public int? DocumentID { get; set; }
        public long? DocumentNo { get; set; }
        public int? VouchareID { get; set; }
        public string VouchareNo { get; set; }
        public int? CompanyID { get; set; }
        public int? status { get; set; }
        public DateTime? TransactionDate { get; set; }
    }
}
