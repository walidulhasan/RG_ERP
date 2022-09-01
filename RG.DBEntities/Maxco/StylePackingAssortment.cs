using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class StylePackingAssortment
    {
        public int Id { get; set; }
        public long StyleId { get; set; }
        public int PackAssortmentId { get; set; }
        public bool? Status { get; set; }
        public string Description { get; set; }
        public int OrderId { get; set; }
    }
}
