using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class CMBL_Unit
    {
        public CMBL_Unit()
        {
            CMBL_ItemUnit = new HashSet<CMBL_ItemUnit>();
            CmblPurchaseOrderItem = new HashSet<CmblPurchaseOrderItem>();
        }
        [Key]
        public int UnitID { get; set; }
        public string UnitDescription { get; set; }
        public string UnitAbbreviation { get; set; }
        public long CompanyID { get; set; }

        public virtual ICollection<CMBL_ItemUnit> CMBL_ItemUnit { get; set; }
        public virtual ICollection<CmblPurchaseOrderItem> CmblPurchaseOrderItem { get; set; }
    }
}
