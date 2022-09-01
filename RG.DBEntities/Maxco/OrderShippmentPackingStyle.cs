using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class OrderShippmentPackingStyle
    {
        public OrderShippmentPackingStyle()
        {
            OrderAssortment = new HashSet<OrderAssortment>();
        }

        public int Id { get; set; }
        public int? ShippmentPackingId { get; set; }
        public int OrderStyleId { get; set; }
        public int? NoOfExtraCartons { get; set; }

        public virtual OrderShippmentPacking ShippmentPacking { get; set; }
        public virtual ICollection<OrderAssortment> OrderAssortment { get; set; }
    }
}
