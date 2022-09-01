using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Embro.Business
{
    public partial class CBM_Cheque
    {
        [Key]
        public decimal ChqID { get; set; }
        public string ChqNum { get; set; }
        public decimal? ChqAccountID { get; set; }
        public int? Status { get; set; }
        public decimal? SignStatus { get; set; }
        public decimal ChqBkID { get; set; }
        public decimal? ChqAmount { get; set; }
        public DateTime? ChqDate { get; set; }
        public string ChqDescription { get; set; }
        public string ChqComments { get; set; }
        public decimal? VoucherID { get; set; }
        public int? ChequeSignatoryID { get; set; }

        public virtual CBM_ChequeBook CBM_ChequeBook { get; set; }
    }
}
