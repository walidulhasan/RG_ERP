using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Embro.Business
{
    public partial class CBM_PrintedCheque
    {
        [Key]
        public long ChqID { get; set; }
        public string ReceivingPerson { get; set; }
        public string Identification { get; set; }
        public int? Status { get; set; }
        public DateTime? TransactionDate { get; set; }
    }
}
