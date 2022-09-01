using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciPalletteSetup
    {
        [Key]
        public int PalletteId { get; set; }
        public string PalletteNo { get; set; }
    }
}
