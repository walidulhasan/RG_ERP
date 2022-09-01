using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcFpManufacturefabricPi
    {
        public int Id { get; set; }
        public int LfpId { get; set; }
        public int LmpId { get; set; }
        public int LfpOrdersheetfabricid { get; set; }
        public decimal LfpRequiredquantity { get; set; }

        //public virtual QrmOrderSheetFabrics LfpOrdersheetfabric { get; set; }
    }
}
