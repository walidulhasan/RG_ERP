using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DdLotSizeMaster
    {
        public DdLotSizeMaster()
        {
            DdLotSizeInventory = new HashSet<DdLotSizeInventory>();
            DdLotSizeIssuance = new HashSet<DdLotSizeIssuance>();
            DdLotSizePurchase = new HashSet<DdLotSizePurchase>();
            DdLotSizeSales = new HashSet<DdLotSizeSales>();
        }

        public int Id { get; set; }
        public int MrpitemCode { get; set; }

        public virtual ICollection<DdLotSizeInventory> DdLotSizeInventory { get; set; }
        public virtual ICollection<DdLotSizeIssuance> DdLotSizeIssuance { get; set; }
        public virtual ICollection<DdLotSizePurchase> DdLotSizePurchase { get; set; }
        public virtual ICollection<DdLotSizeSales> DdLotSizeSales { get; set; }
    }
}
