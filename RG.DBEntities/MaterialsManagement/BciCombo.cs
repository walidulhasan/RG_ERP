using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciCombo
    {
        [Key]
        public int ComboId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
