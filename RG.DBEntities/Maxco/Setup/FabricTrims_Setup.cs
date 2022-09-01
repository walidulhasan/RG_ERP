using RG.DBEntities.Maxco.FabricAndYarn;
using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Setup
{
    public class FabricTrims_Setup
    {
        public FabricTrims_Setup()
        {
            FabricTrimSelected = new HashSet<FabricTrimSelected>();
        }
        public int ID { get; set; }
        public string Description { get; set; }
        public string HomePage { get; set; }
        public string AjtHomePage { get; set; }
        public virtual ICollection<FabricTrimSelected> FabricTrimSelected { get; set; }
    }
}
