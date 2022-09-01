using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class Modelcostingfabric
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public decimal? Consumption { get; set; }
    }
}
