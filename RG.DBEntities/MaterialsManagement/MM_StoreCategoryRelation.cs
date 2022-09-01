using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MM_StoreCategoryRelation
    {
        public int ID { get; set; }
        public int StoreID { get; set; }
        public int StoreCategoryID { get; set; }
        public long? CompanyID { get; set; }

        //public virtual MM_Store_Setup Store { get; set; }
        //public virtual MmStoreCategorySetup StoreCategory { get; set; }
    }
}
