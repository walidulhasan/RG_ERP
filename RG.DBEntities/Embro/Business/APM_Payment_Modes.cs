using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Embro.Business
{
    public partial class APM_Payment_Modes
    {
        //public APM_Payment_Modes()
        //{
        //    ApmPaymentModesDetail = new HashSet<ApmPaymentModesDetail>();
        //}
        [Key]
        public decimal MOPID { get; set; }
        public string MOPName { get; set; }
        public string MOPDescription { get; set; }

       // public virtual ICollection<ApmPaymentModesDetail> ApmPaymentModesDetail { get; set; }
    }
}
