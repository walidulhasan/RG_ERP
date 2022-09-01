using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblPotype
    {
        [Key]
        public byte PotypeId { get; set; }
        public string PotypeDescription { get; set; }
    }
}
