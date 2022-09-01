using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblFiintegerationOld
    {
        [Key]
        public int? DocumentTypeId { get; set; }
        public long? DocumentId { get; set; }
        public string VoucherNo { get; set; }
        public long? VoucherId { get; set; }
        public long? CompanyId { get; set; }
    }
}
