using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TblOrderPono
    {
        public long Id { get; set; }
        public long? Orderid { get; set; }
        public long? Styleid { get; set; }
        public string Pono { get; set; }
        public DateTime? Creationdate { get; set; }
    }
}
