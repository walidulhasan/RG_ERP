using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class OrderStatusIndex
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public string StatusDesc { get; set; }
        public string Color { get; set; }
    }
}
