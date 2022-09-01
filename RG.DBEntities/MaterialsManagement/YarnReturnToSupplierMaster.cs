using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnReturnToSupplierMaster
    {
        public long Yrtsid { get; set; }
        public string Yrtsno { get; set; }
        public long YarnPermRecId { get; set; }
        public long Poid { get; set; }
        public DateTime Yrtsdate { get; set; }
        public int Status { get; set; }
    }
}
