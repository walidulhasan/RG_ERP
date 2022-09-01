using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class TwillTapeWeave_Setup
    {
        public TwillTapeWeave_Setup()
        {
            TwillTapeSpecification = new HashSet<TwillTapeSpecification>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TwillTapeSpecification> TwillTapeSpecification { get; set; }
    }
}
