using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcCdChildDetailDeleted
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Actiondate { get; set; }
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
    }
}
