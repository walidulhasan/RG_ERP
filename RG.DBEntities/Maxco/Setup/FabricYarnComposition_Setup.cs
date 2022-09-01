using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;


namespace RG.DBEntities.Maxco.Setup
{
    public partial class FabricYarnComposition_Setup
    {
        public FabricYarnComposition_Setup()
        {
            FabricYarnCosting_Setup = new HashSet<FabricYarnCosting_Setup>();
            FabricYarnSpecification = new HashSet<FabricYarnSpecification>();
            //FurYarnSpecification = new HashSet<FurYarnSpecification>();
            //GreigeFabricYarnSpecification = new HashSet<GreigeFabricYarnSpecification>();
            //TwillTapeYarnSpecification = new HashSet<TwillTapeYarnSpecification>();
        }

        public int ID { get; set; }
        public string Description { get; set; }
        public bool? IsMix { get; set; }
        public double? CottonRatio { get; set; }
        public double? PolyesterRatio { get; set; }
        public double? LycraRatio { get; set; }
        [ForeignKey("GenericFabricCompositionSetup_Master")]
        public long? isNewComposition { get; set; }
        public double? CnvCtnRatio { get; set; }
        public double? OrgCtnRatio { get; set; }
        public int? IsDeleted { get; set; }

        public virtual ICollection<FabricYarnCosting_Setup> FabricYarnCosting_Setup { get; set; }
        public virtual ICollection<FabricYarnSpecification> FabricYarnSpecification { get; set; }

      //  public virtual ICollection<FurYarnSpecification> FurYarnSpecification { get; set; }
       // public virtual ICollection<GreigeFabricYarnSpecification> GreigeFabricYarnSpecification { get; set; }
      //  public virtual ICollection<TwillTapeYarnSpecification> TwillTapeYarnSpecification { get; set; }

        public GenericFabricCompositionSetup_Master GenericFabricCompositionSetup_Master { get; set; }


    }
}
