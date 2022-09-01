using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Embro.Business
{
    public class CBM_RFP_Detail
    {
        [Key,Column(Order=0)]
        public decimal RFPID { get; set; }
        [Key, Column(Order = 1)]
        public decimal InvoiceID { get; set; }

        public virtual CBM_RFP Rfp { get; set; }
    }
}
