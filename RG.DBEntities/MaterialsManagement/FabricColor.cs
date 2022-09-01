using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class FabricColor
    {
        public int Id { get; set; }
        public int Ykncid { get; set; }
        public int ColorId { get; set; }
        public double? Quantity { get; set; }
    }
}
