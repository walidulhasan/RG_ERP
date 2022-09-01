using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class OrderShippmentTermSetup
    {
        public OrderShippmentTermSetup()
        {
            OrderShippment = new HashSet<OrderShippment>();
        }

        public short Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<OrderShippment> OrderShippment { get; set; }
    }
}
