using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcOmOrderMap
    {
        public int Id { get; set; }
        public int LomId { get; set; }
        public int LscId { get; set; }
        public int Orderid { get; set; }
        public decimal LomCurrentquantity { get; set; }
    }
}
