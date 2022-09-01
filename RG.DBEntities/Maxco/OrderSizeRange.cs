using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class OrderSizeRange
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public string SizeDescription { get; set; }

        public virtual OrderSelectedStyle Model { get; set; }
    }
}
