using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ZipPullerMaterialSetup
    {
        public ZipPullerMaterialSetup()
        {
            ZipPullerImageSetup = new HashSet<ZipPullerImageSetup>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ZipPullerImageSetup> ZipPullerImageSetup { get; set; }
    }
}
