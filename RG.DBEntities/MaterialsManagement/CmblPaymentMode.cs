using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblPaymentMode
    {
        [Key]
        public int Pmid { get; set; }
        public string Pmdescription { get; set; }
        public int CompanyId { get; set; }
    }
}
