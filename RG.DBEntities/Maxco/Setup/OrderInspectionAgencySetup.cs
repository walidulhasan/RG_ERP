using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class OrderInspectionAgencySetup
    {
        public byte Id { get; set; }
        public string Description { get; set; }
        public byte? BuyerId { get; set; }
    }
}
