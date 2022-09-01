using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Trims
{
    public class TrimInsertion_Setup
    {
        public int ID { get; set; }
        public int TrimID { get; set; }
        public int InsertionID { get; set; }

        public virtual Insertion_Setup Insertion { get; set; }
        public virtual Trim_Setup Trim { get; set; }
    }
}
