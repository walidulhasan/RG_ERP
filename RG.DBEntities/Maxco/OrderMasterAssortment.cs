using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class OrderMasterAssortment
    {
        public int Id { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int NoOfMasters { get; set; }
        public int ModelId { get; set; }
        public int? PerMasterGarments { get; set; }

        public virtual OrderSelectedStyle Model { get; set; }
    }
}
