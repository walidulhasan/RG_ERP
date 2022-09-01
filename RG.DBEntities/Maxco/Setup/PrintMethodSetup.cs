using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class PrintMethodSetup
    {
        public PrintMethodSetup()
        {
            PrintEmbroImageSetup = new HashSet<PrintEmbroImage_Setup>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PrintEmbroImage_Setup> PrintEmbroImageSetup { get; set; }
    }
}
