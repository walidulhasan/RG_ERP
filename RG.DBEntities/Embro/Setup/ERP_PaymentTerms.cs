using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.Embro.Setup
{
    public class ERP_PaymentTerms
    {
        [Key]
        public int PTID { get; set; }
        public string PTDescription { get; set; }
        public int CompanyID { get; set; }
        public int? NoOfDays { get; set; }
        public bool? IsDisplay { get; set; }
        public int? PaymentModeID { get; set; }
    }
}
