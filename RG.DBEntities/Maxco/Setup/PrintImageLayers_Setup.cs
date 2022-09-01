using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class PrintImageLayers_Setup
    {
        public int ID { get; set; }
        public int PrintImageSetupID { get; set; }
        public string ImagePath { get; set; }

        public virtual PrintEmbroImage_Setup PrintImageSetup { get; set; }
    }
}
