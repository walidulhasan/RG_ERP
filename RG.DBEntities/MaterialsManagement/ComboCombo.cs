using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class ComboCombo
    {
        [Key]
        public long ComboId { get; set; }
        public string ComboCode { get; set; }
    }
}
