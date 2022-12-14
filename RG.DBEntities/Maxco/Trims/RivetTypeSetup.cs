using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class RivetTypeSetup
    {
        public RivetTypeSetup()
        {
            RivetImageSetup = new HashSet<RivetImageSetup>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RivetImageSetup> RivetImageSetup { get; set; }
    }
}
