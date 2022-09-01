using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class TblIndWorkorderDetails
    {
        public long Id { get; set; }
        public long? WorkorderId { get; set; }
        public long? Sn { get; set; }
        public string Itemname { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? Quantity { get; set; }
        public long? Status { get; set; }
        public int? Unitid { get; set; }
    }
}
