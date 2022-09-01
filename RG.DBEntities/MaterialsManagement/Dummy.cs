using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class Dummy
    {
        [Key]
        public string Pono { get; set; }
    }
}
