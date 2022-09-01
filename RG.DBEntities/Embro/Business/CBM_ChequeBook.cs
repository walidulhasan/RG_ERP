using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Embro.Business
{
    public class CBM_ChequeBook
    {
        public CBM_ChequeBook()
        {
            CBM_Cheque = new HashSet<CBM_Cheque>();
        }

        public decimal ID { get; set; }
        public string Prefix { get; set; }
        public string SeriesStart { get; set; }
        public string SeriesEnd { get; set; }
        public int AccountID { get; set; }
        public string Status { get; set; }

        public virtual ICollection<CBM_Cheque> CBM_Cheque { get; set; }
    }
}
