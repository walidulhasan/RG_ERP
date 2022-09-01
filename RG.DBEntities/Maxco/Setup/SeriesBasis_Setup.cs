using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class SeriesBasis_Setup
    {
        public SeriesBasis_Setup()
        {
            Series = new HashSet<Series>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Series> Series { get; set; }
    }
}
