using RG.DBEntities.Embro.Business;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Setup
{
    public partial class ClosingTypes
    {
        public ClosingTypes()
        {
            ClosingDates = new HashSet<ClosingDates>();
        }

        public int ID { get; set; }
        public string Type { get; set; }

        public virtual ICollection<ClosingDates> ClosingDates { get; set; }
    }
}
