using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class TwillTapeWidth_Setup
    {
        public TwillTapeWidth_Setup()
        {
            TwillTapeSpecification = new HashSet<TwillTapeSpecification>();
        }

        public int ID { get; set; }
        public double Description { get; set; }

        public virtual ICollection<TwillTapeSpecification> TwillTapeSpecification { get; set; }
    }
}
