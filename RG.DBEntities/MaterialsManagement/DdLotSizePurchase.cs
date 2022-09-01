using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DdLotSizePurchase
    {
        public int Id { get; set; }
        public int UnitId { get; set; }
        public double ConversionRate { get; set; }
        public double MinPurchaseQty { get; set; }
        public int LsmasterId { get; set; }

        public virtual DdLotSizeMaster Lsmaster { get; set; }
    }
}
