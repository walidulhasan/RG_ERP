using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricYarnCount_Setup
    {
        public FabricYarnCount_Setup()
        {
            FabricYarnSpecification = new HashSet<FabricYarnSpecification>();
            //FabricYarnSpecificationSetup = new HashSet<FabricYarnSpecificationSetup>();
            //FurYarnSpecification = new HashSet<FurYarnSpecification>();
            //GreigeFabricYarnSpecification = new HashSet<GreigeFabricYarnSpecification>();
            //TwillTapeYarnSpecification = new HashSet<TwillTapeYarnSpecification>();
        }

        public long ID { get; set; }
        public string Description { get; set; }
        public int? FabricYarnCompositionID { get; set; }
        public int IsDisplay { get; set; }
        public string DesFYCI { get; set; }
        public int? IsDeleted { get; set; }

        public virtual ICollection<FabricYarnSpecification> FabricYarnSpecification { get; set; }
       // public virtual ICollection<FabricYarnSpecificationSetup> FabricYarnSpecificationSetup { get; set; }
       // public virtual ICollection<FurYarnSpecification> FurYarnSpecification { get; set; }
      //  public virtual ICollection<GreigeFabricYarnSpecification> GreigeFabricYarnSpecification { get; set; }
       // public virtual ICollection<TwillTapeYarnSpecification> TwillTapeYarnSpecification { get; set; }
    }
}
