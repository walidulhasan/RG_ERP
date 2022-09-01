using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class OrderColorRange
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public string PantoneNo { get; set; }

        public virtual OrderSelectedStyle Model { get; set; }
    }
}
