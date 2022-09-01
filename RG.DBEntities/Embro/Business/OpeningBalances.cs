using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Embro.Business
{
    public partial class OpeningBalances
    {
        public decimal AccountID { get; set; }
        public decimal OpeningBalance { get; set; }
        public int? CostCenterID { get; set; }
        public int? ActivityID { get; set; }
        public int? LocationID { get; set; }
        public int FiscalYear { get; set; }
        public DateTime RDATE { get; set; }
        [Key]
        public long VID { get; set; }
    }
}
