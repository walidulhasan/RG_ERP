using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciUniqueAssortementDetail
    {
        public long Id { get; set; }
        public string SingleBarCode { get; set; }
        public long MasterId { get; set; }

        public virtual BciUniqueAssortementMaster Master { get; set; }
    }
}
