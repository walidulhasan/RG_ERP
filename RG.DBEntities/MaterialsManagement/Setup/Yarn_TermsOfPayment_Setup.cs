using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class Yarn_TermsOfPayment_Setup
    {
        [Key]
        public int TOPID { get; set; }
        public string TOPDesc { get; set; }
        public int? PaymentModeID { get; set; }
    }
}
