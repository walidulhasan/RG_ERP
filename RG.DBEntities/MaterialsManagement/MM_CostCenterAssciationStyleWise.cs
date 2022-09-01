using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MM_CostCenterAssciationStyleWise
    {
        public long ID { get; set; }
        public long FabricCategoryID { get; set; }
        public long CompanyID { get; set; }
        public long BusinessID { get; set; }
        public long LocationID { get; set; }
        public long CCID { get; set; }
        public int ActivityID { get; set; }
    }
}
