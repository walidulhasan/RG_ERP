using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class Yarn_WOMaster
    {
        public long Yarn_WOID { get; set; }
        public string YarnWONo { get; set; }
        public int? WOTypeID { get; set; }
        public int? SupplierID { get; set; }
        public int? ModeID { get; set; }
        public int? TermID { get; set; }
        public int? YarnStoreLocationID { get; set; }
        public int? IsCommercial { get; set; }
        public int? LifeCycleStatus { get; set; }
        public int? UserID { get; set; }
        public int? ProgramTypeID { get; set; }
        public int? OrderID { get; set; }
        public string OrderNo { get; set; }
        public int? DaysOfPayment { get; set; }
        public DateTime? WODate { get; set; }
        public string Comments { get; set; }
        public string ReferenceNumber { get; set; }
    }
}
