using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco
{
    public partial class PrintEmbroSpecifications
    {
        public int Id { get; set; }
        public int PrintId { get; set; }
        public int EmbroId { get; set; }
        public int PrintEmbroImageId { get; set; }

        public virtual PrintingSpecification Print { get; set; }
        public virtual PrintEmbroImage_Setup PrintEmbroImage { get; set; }
    }
}
