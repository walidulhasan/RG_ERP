using RG.DBEntities.Embro.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Embro.Setup
{
    public class ChequeSignatoryDetail
    {
        [ForeignKey("ChequeSignatoryMaster")]
        public int ChequeSignatoryID { get; set; }
        [ForeignKey("Signatory")]
        public int SignatoryID { get; set; }

        public virtual ChequeSignatoryMaster ChequeSignatoryMaster { get; set; }
        public virtual Signatory Signatory { get; set; }
    }
}
