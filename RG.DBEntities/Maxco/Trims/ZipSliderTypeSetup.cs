using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ZipSliderTypeSetup
    {
        public ZipSliderTypeSetup()
        {
            ZipSpecification = new HashSet<ZipSpecification>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ZipSpecification> ZipSpecification { get; set; }
    }
}
