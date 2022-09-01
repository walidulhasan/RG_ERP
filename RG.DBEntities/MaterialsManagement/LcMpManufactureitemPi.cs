using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class LcMpManufactureitemPi
    {
        public LcMpManufactureitemPi()
        {
            LcFpManufacturefabricPi = new HashSet<LcFpManufacturefabricPi>();
        }
        [Key]
        public int LmpId { get; set; }
        public string LmpCode { get; set; }
        public int LpoId { get; set; }

        public virtual ICollection<LcFpManufacturefabricPi> LcFpManufacturefabricPi { get; set; }
    }
}
