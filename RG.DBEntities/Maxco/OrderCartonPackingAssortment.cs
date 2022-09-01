using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class OrderCartonPackingAssortment
    {
        public int Id { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int NoOfCartons { get; set; }
        public int ModelId { get; set; }
        public int? PerCartonMasters { get; set; }
        public int TotalCartonsForThisColor { get; set; }
        public int? TotalCartonsDispatched { get; set; }

        public virtual OrderSelectedStyle Model { get; set; }
    }
}
