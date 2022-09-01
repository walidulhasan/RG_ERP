﻿using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class RivetSizeSetup
    {
        public RivetSizeSetup()
        {
            RivetSpecification = new HashSet<RivetSpecification>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RivetSpecification> RivetSpecification { get; set; }
    }
}
