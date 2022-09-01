using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Trims
{
    public class TrimCategory_Setup
    {
        public TrimCategory_Setup()
        {
            TrimSetup = new HashSet<Trim_Setup>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Trim_Setup> TrimSetup { get; set; }
    }
}
