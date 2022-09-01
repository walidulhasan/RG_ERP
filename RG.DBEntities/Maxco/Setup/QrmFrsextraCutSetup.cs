using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class QrmFrsextraCutSetup
    {
        public int Id { get; set; }
        public int? BuyerId { get; set; }
        public string Description { get; set; }
        public double? Value { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
