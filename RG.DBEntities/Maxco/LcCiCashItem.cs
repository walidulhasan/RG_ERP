using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcCiCashItem
    {
        public int Id { get; set; }
        public int LciId { get; set; }
        public int LcdId { get; set; }
        public int? LciAttributeinstanceid { get; set; }
        public int? LciItemId { get; set; }
        public decimal LciQuantity { get; set; }
        public int LciUnit { get; set; }
        public decimal LciUnitprice { get; set; }
        public int? LfpId { get; set; }
    }
}
