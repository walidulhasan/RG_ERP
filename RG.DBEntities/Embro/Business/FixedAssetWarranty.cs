﻿using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class FixedAssetWarranty
    {
        public decimal AssetId { get; set; }
        public DateTime? WarrantyStartDate { get; set; }
        public DateTime? WarrantyEndDate { get; set; }
        public string WarrantyDesc { get; set; }
    }
}
