using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ZipNumberSetup
    {
        public ZipNumberSetup()
        {
            ZipSpecification = new HashSet<ZipSpecification>();
        }

        public int Id { get; set; }
        public double Number { get; set; }

        public virtual ICollection<ZipSpecification> ZipSpecification { get; set; }
    }
}
