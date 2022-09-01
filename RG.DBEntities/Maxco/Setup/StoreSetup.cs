using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class StoreSetup
    {
        public StoreSetup()
        {
            StoreLocationSetup = new HashSet<StoreLocationSetup>();
            TrimPodeliveries = new HashSet<TrimPodeliveries>();
        }
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string StoreDesc { get; set; }

        public virtual ICollection<StoreLocationSetup> StoreLocationSetup { get; set; }
        public virtual ICollection<TrimPodeliveries> TrimPodeliveries { get; set; }
    }
}
