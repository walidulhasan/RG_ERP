using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciMainCombo
    {
        [Key]
        public decimal ComboId { get; set; }
        public string StyleCode { get; set; }
        public string ColorCode { get; set; }
        public string AssortmentCode { get; set; }
    }
}
