using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class TransactionLogSetup
    {
        public TransactionLogSetup()
        {
            GarmentAssortmentTransactionLog = new HashSet<GarmentAssortmentTransactionLog>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<GarmentAssortmentTransactionLog> GarmentAssortmentTransactionLog { get; set; }
    }
}
