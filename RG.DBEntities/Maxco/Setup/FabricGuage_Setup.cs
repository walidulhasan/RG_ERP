using RG.DBEntities.Maxco.FabricAndYarn;
using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Setup
{
    public class FabricGuage_Setup
    {
        public FabricGuage_Setup()
        {
            FabricSpecification = new HashSet<FabricSpecification>();
            GreigeFabricCodeSetup = new HashSet<GreigeFabricCode_Setup>();
            KnittingExperiment = new HashSet<KnittingExperiment>();
        }

        public int ID { get; set; }
        public string Description { get; set; }
        public int StartGSM { get; set; }
        public int EndGSM { get; set; }

        public virtual ICollection<FabricSpecification> FabricSpecification { get; set; }
        public virtual ICollection<GreigeFabricCode_Setup> GreigeFabricCodeSetup { get; set; }
        public virtual ICollection<KnittingExperiment> KnittingExperiment { get; set; }
    }
}
