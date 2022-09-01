using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ZipStudMaterialSetup
    {
        public ZipStudMaterialSetup()
        {
            ZipStudImageSetup = new HashSet<ZipStudImageSetup>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ZipStudImageSetup> ZipStudImageSetup { get; set; }
    }
}
