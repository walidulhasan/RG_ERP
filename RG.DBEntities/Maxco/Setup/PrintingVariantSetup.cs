using RG.DBEntities.Maxco.FabricAndYarn;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class PrintingVariantSetup
    {
        public PrintingVariantSetup()
        {
            PrintingSpecification = new HashSet<PrintingSpecification>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PrintingSpecification> PrintingSpecification { get; set; }
    }
}
