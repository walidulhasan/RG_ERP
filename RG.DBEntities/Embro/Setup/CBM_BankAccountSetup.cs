using RG.DBEntities.Embro.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Embro.Setup
{
    public partial class CBM_BankAccountSetup
    {

        public int ID { get; set; }
        [ForeignKey("BasicCOA")]
        public decimal BAccountID { get; set; }
        public string BAccountName { get; set; }
        [ForeignKey("Type")]
        public decimal? TypeID { get; set; }
        [ForeignKey("CBM_Currency")]
        public int? CurrID { get; set; }

        [ForeignKey("CBM_Branch")]
        public int? BranchID { get; set; }
        public decimal? Limit { get; set; }
        public string LRemarks { get; set; }

        public virtual BasicCOA BasicCOA { get; set; }
        public virtual CBM_Branch CBM_Branch { get; set; }
        public virtual CBM_Currency CBM_Currency { get; set; }
        public virtual BasicCOA Type { get; set; }
    }
}
