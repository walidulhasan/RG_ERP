using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class MaterialManagementJobItems
    {
        public int Id { get; set; }
        public int SamplingItemCode { get; set; }
        public int SampleSuperBomid { get; set; }
        public int ObjectId { get; set; }
        public int Status { get; set; }
        public int? VendorId { get; set; }
        public int? StoreId { get; set; }
        public int JobId { get; set; }

        public virtual SampleMirmaterialManagement Job { get; set; }
    }
}
