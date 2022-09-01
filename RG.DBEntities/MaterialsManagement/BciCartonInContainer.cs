using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciCartonInContainer
    {
        [Key]
        public long CartonNo { get; set; }
        public long Container { get; set; }
    }
}
