using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricType_Setup 
    {
        public FabricType_Setup()
        {
            FabricQualitySetup = new HashSet<FabricQuality_Setup>();
        }

        public int ID { get; set; }
        public string Description { get; set; }
        [ForeignKey("FabricCategory_setup")]
        public int? FabricCategoryID { get; set; }


        public virtual FabricCategory_setup FabricCategory_setup { get; set; }
        public virtual ICollection<FabricQuality_Setup> FabricQualitySetup { get; set; }
    }
}
