using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmStoreLocationTransferMaster
    {
        public long MtransferId { get; set; }
        public DateTime MtransferDate { get; set; }
        public string MtransferNo { get; set; }
    }
}
