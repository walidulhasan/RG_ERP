using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class YarnBrokerSetup
    {
        [Key]
        public int YarnBrokerID { get; set; }
        public string Name { get; set; }
        public string BrokerCode { get; set; }
        public string Address { get; set; }
    }
}
