using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class RupeeConversion
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Rate { get; set; }
    }
}
