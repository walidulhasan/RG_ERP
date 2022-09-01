using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Embro.Business
{
    public partial class CBM_ECFDetail
    {
        public int ID { get; set; }
        [ForeignKey("CBM_ECF")]
        public decimal? ECFID { get; set; }
        public string Particulars { get; set; }
        public decimal? AccountID { get; set; }
        public decimal? RefID { get; set; }
        public string RefNo { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Amount { get; set; }
        public decimal? LocationID { get; set; }
        public decimal? CostCenterID { get; set; }
        public decimal? ActivityID { get; set; }
        public DateTime? ExpenseDate { get; set; }
        public virtual CBM_ECF CBM_ECF { get; set; }
    }
}
