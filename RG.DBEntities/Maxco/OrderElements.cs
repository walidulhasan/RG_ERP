using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class OrderElements
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public bool GarmentAssortment { get; set; }
        public bool PackingAssortment { get; set; }
        public bool Models { get; set; }
    }
}
