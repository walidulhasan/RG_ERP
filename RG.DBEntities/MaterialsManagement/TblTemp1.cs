using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class TblTemp1
    {
        public long? SNo { get; set; }
        public string Order { get; set; }
        public string FabricType { get; set; }
        public string Quality { get; set; }
        public string FabricComposition { get; set; }
        public int? Gsm { get; set; }
        public int? Width { get; set; }
        public string Color { get; set; }
        public long? OrderQty { get; set; }
        public int? GroupSet { get; set; }
        public string FabricSpecs { get; set; }
        public string KnittingDate { get; set; }
        public double? ReceivedUpKd { get; set; }
        public double? GreigeQty { get; set; }
        public double? GreigeDelivered { get; set; }
        public decimal? FinishQty { get; set; }
        public double? FinishDelivered { get; set; }
        public double? Balance { get; set; }
        public string DeliveryDate { get; set; }
        public int? Overdue { get; set; }
    }
}
