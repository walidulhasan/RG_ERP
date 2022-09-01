using RG.DBEntities.Maxco.FabricAndYarn;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.Setup
{
    public class FabricQuality_Setup
    {
        public FabricQuality_Setup()
        {
           // CadcamFinishedFabricWastageSetup = new HashSet<CadcamFinishedFabricWastageSetup>();
            FabricSpecification = new HashSet<FabricSpecification>();
           // GreigeFabricCodeSetup = new HashSet<GreigeFabricCodeSetup>();
        }

        public int ID { get; set; }
        [ForeignKey("FabricType_Setup")]
        public int TypeID { get; set; }
        public string Description { get; set; }

        public virtual FabricType_Setup FabricType_Setup { get; set; }
      //  public virtual ICollection<CadcamFinishedFabricWastageSetup> CadcamFinishedFabricWastageSetup { get; set; }
        public virtual ICollection<FabricSpecification> FabricSpecification { get; set; }
       // public virtual ICollection<GreigeFabricCodeSetup> GreigeFabricCodeSetup { get; set; }
    }
}
