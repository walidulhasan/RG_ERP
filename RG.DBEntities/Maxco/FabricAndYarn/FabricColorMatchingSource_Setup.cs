using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricColorMatchingSource_Setup
    {
        public FabricColorMatchingSource_Setup()
        {
            FabricSpecification = new HashSet<FabricSpecification>();
           // SeriesColors = new HashSet<SeriesColors>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FabricSpecification> FabricSpecification { get; set; }
      //  public virtual ICollection<SeriesColors> SeriesColors { get; set; }
    }
}
