using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class BuyerWarehouseSetup
    {
        public int Id { get; set; }
        public int? BuyerId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
    }
}
