using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.Embro.Setup
{
    public class ERP_PaymentModes
    {
        [Key]
        public int PMID { get; set; }
        public string PMDescription { get; set; }
        public int CompanyID { get; set; }
    }
}
