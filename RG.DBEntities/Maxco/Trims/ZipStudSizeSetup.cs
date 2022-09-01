using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ZipStudSizeSetup
    {
        public ZipStudSizeSetup()
        {
            ZipStudSpecification = new HashSet<ZipStudSpecification>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ZipStudSpecification> ZipStudSpecification { get; set; }
    }
}
