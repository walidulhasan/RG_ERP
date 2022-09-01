using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class AC_WCWiseSum_View
    {
        public string WcDescrip { get; set; }
        public double? RecQty { get; set; }
        public double? InsQty { get; set; }
        public double? ConfirmedQty { get; set; }
        public double? RejQty { get; set; }
        public double? DelQty { get; set; }
        public int WcId { get; set; }
    }
}
