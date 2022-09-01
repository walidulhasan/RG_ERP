using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class SfsDocumentType
    {
        public SfsDocumentType()
        {
            SfsStockTransaction = new HashSet<SfsStockTransaction>();
        }

        public int DocumentTypeId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentDescription { get; set; }
        public string Initials { get; set; }

        public virtual ICollection<SfsStockTransaction> SfsStockTransaction { get; set; }
    }
}
