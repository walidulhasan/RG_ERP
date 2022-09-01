using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco
{
    public partial class GarmentAssortmentTransactionLog
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public int StyleId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Ipaddress { get; set; }

        public virtual TransactionLogSetup Transaction { get; set; }
    }
}
