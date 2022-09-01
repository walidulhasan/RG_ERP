using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciContainerSetup
    {
        [Key]
        public long ContainerId { get; set; }
        public string ContainerNo { get; set; }
    }
}
