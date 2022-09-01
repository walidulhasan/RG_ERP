using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciCartonReceivingDetail
    {
        public int Id { get; set; }
        public int BciCartonReceivingMasterId { get; set; }
        public int BciCartonSetupMasterId { get; set; }

        public virtual BciCartonReceivingMaster BciCartonReceivingMaster { get; set; }
    }
}
