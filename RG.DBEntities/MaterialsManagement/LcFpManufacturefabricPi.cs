using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class LcFpManufacturefabricPi
    {
        [Key]
        public int LfpId { get; set; }
        public int LmpId { get; set; }
        public int LfpOrdersheetfabricid { get; set; }
        public decimal LfpRequiredquantity { get; set; }

        public virtual LcMpManufactureitemPi Lmp { get; set; }
    }
}
