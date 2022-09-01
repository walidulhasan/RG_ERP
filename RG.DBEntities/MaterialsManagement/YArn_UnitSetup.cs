using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YArn_UnitSetup
    {
        [Key]
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public string DisplayName { get; set; }
        public byte isSKU { get; set; }
        public double SKUConversion { get; set; }
    }
}
