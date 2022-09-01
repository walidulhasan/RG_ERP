using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class PackingAccessoriesSetup
    {
        public PackingAccessoriesSetup()
        {
            PackingAccessoriesTypesSetup = new HashSet<PackingAccessoriesTypesSetup>();
        }

        public short Id { get; set; }
        public string Description { get; set; }
        public string HomePage { get; set; }
        public string DisplayPage { get; set; }
        public int? IsDisplay { get; set; }

        public virtual ICollection<PackingAccessoriesTypesSetup> PackingAccessoriesTypesSetup { get; set; }
    }
}
