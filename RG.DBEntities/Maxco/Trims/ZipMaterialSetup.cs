using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ZipMaterialSetup
    {
        public ZipMaterialSetup()
        {
            ZipSpecification = new HashSet<ZipSpecification>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ZipSpecification> ZipSpecification { get; set; }
    }
}
