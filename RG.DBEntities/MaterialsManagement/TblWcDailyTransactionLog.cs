using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class TblWcDailyTransactionLog
    {
        public decimal TransId { get; set; }
        public int WcId { get; set; }
        public DateTime TransDate { get; set; }
        public long OrderId { get; set; }
        public long StyleId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public double RecQty { get; set; }
        public double ConfirmedQty { get; set; }
        public double InsQty { get; set; }
        public double RejQty { get; set; }
        public double DelQty { get; set; }
        public bool? Deleted { get; set; }
        public double Smv { get; set; }
        public double Qrmrate { get; set; }
        public double StyleValue { get; set; }
        public int FabricCategoryId { get; set; }
        public int QualityId { get; set; }
    }
}
