using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class Tansaction_Setup
    {
        public Tansaction_Setup()
        {
            Style_Transactions = new HashSet<Style_Transactions>();
        }

        public byte ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Style_Transactions> Style_Transactions { get; set; }
    }
}
