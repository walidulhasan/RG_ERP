using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class GreigeQualityAttributes
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool? IsOptional { get; set; }
    }
}
