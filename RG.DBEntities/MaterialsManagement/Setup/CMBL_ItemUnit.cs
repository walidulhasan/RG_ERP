using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class CMBL_ItemUnit
    {
        [Key]
        public long ItemID { get; set; }
        public int UnitID { get; set; }
        public double SKUConversion { get; set; }

        public virtual CMBL_Item CMBL_Item { get; set; }
        public virtual CMBL_Unit CMBL_Unit { get; set; }
    }
}
