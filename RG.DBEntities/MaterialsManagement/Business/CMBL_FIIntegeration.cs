using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class CMBL_FIIntegeration
    {
        [Key]
        public int? DocumentTypeID { get; set; }
        public long? DocumentID { get; set; }
        public string VoucherNo { get; set; }
        public long? VoucherID { get; set; }
        public long? CompanyID { get; set; }
        public int Deleted { get; set; }
    }
}
