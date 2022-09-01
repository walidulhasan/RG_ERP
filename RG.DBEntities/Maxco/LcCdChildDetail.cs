using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class LcCdChildDetail
    {
     [Key]
        public int LcdId { get; set; }
        public int LmcId { get; set; }
        public int Attributeinstanceid { get; set; }
        public int OrderId { get; set; }
        public int OfsverId { get; set; }
        public int? Poid { get; set; }
        public decimal LmcRequiredqty { get; set; }
        public decimal LmcRate { get; set; }
        public int Unitid { get; set; }
        public int Currencyid { get; set; }

        public virtual LC_MC_MASTER_CHILD Lmc { get; set; }
    }
}
